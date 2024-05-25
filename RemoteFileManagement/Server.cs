﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using static System.Windows.Forms.LinkLabel;

namespace RemoteFileManagement
{
    public partial class Server : Form
    {
        TcpListener server;
        //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        public Server()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void ButtonListen_Click(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Loopback, 2024);
            server.Start();
            Thread listen_thread = new Thread(ListenThread);
            listen_thread.IsBackground = true;
            listen_thread.Start();

        }

        private async void ClientThread(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            while(true)
            {
                byte[] buffer = new byte[1024];
                stream.Read(buffer, 0, buffer.Length);
                string path = Encoding.ASCII.GetString(buffer);

                //hard buffer for incoming file path request is 1024 bytes
                //send requested file to client
                if (path != null)
                {
                    //send file
                    try
                    {
                        FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                        int bytesRead = 0;
                        //stream file directly to client
                        await file.CopyToAsync(stream);
                        file.Close();
                    }
                    catch
                    {

                    }

                    //send file name
                    try
                    {
                        string fileName = Path.GetFileName(path);
                        byte[] fileNameBytes = Encoding.ASCII.GetBytes(fileName);
                        stream.Read(fileNameBytes, 0, fileNameBytes.Length);
                        

                    }
                    catch
                    {
                                                
                    }
                }
            }
        }

        private async void EncryptFileAES(string path, string result, RSACryptoServiceProvider rsa)
        {
            result = await Task.Run(() => {
                //string path = (string)obj;
                string outputpath = Path.ChangeExtension(path, ".enc");
                if (!File.Exists(path))
                {
                    outputpath = null;
                    return outputpath;
                }
                if (File.Exists(outputpath))
                {
                    File.Delete(outputpath);
                }
                //handle input file not found
                Aes aes = Aes.Create();
                ICryptoTransform transform = aes.CreateEncryptor();
                int aesIVLength = aes.IV.Length;
                byte[] aesIVlen = BitConverter.GetBytes(aesIVLength);

                //encrypt aes key with rsa for secure transfer
                byte[] encryptedAESKey = rsa.Encrypt(aes.Key, false);
                byte[] encryptedAESKeyLength = BitConverter.GetBytes(encryptedAESKey.Length);

                FileStream filestream_out = null;
                try
                {
                    filestream_out = new FileStream(outputpath, FileMode.Create, FileAccess.Write);
                    filestream_out.Seek(0, SeekOrigin.Begin);
                    //write encrypted aes key length to file
                    filestream_out.Write(encryptedAESKeyLength, 0, 4);
                    // 0 to 4 bytes are IV length
                    filestream_out.Write(aesIVlen, 0, 4);
                    //write encrypted aes key to file
                    filestream_out.Write(encryptedAESKey, 0, encryptedAESKey.Length);
                    //write IV to file
                    filestream_out.Write(aes.IV, 0, aesIVLength);
                }
                catch
                {
                    outputpath = null;
                    return outputpath;
                }

                try
                {
                    CryptoStream cryptoStream = new CryptoStream(filestream_out, transform, CryptoStreamMode.Write);
                    //encrypt a chunk at a time
                    int count = 0;
                    int offset = 0;

                    //set block size to 1/8 of the aes block size
                    int blockSize = aes.BlockSize / 8;
                    byte[] data = new byte[blockSize];
                    int bytesRead = 0;

                    FileStream fileStream_in = new FileStream(path, FileMode.Open, FileAccess.Read);
                    do
                    {
                        count = fileStream_in.Read(data, 0, blockSize);
                        offset += count;
                        cryptoStream.Write(data, 0, count);
                        bytesRead += blockSize;
                    }
                    while (count > 0);

                    cryptoStream.FlushFinalBlock();
                    filestream_out.Close();
                    fileStream_in.Close();
                }
                catch
                {
                    outputpath = null;
                    return outputpath;
                }

                return outputpath;
            });
            
        }

        private void ListenThread()
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Thread client_thread = new Thread(ClientThread);
                client_thread.IsBackground = true;
                client_thread.Start(client);
               
            }


        }

        private async void DecryptFileAES(string path, string filename, string result, RSACryptoServiceProvider rsa)
        {
            result = await Task.Run(() =>
            {

                //combine file name with path
                string outputpath = Path.Combine(Path.GetDirectoryName(path), filename);

                if(File.Exists(outputpath))
                {
                    File.Delete(outputpath);
                }

                Aes aes = Aes.Create();

                //bytes array to store encrypted aes key length and IV length
                byte[] encrypted_key_len = new byte[4];
                byte[] IV_len = new byte[4];
                

                FileStream fileStream_in = null;
                try
                {
                    fileStream_in = new FileStream(path, FileMode.Open, FileAccess.Read);
                    fileStream_in.Seek(0, SeekOrigin.Begin);
                    fileStream_in.Read(encrypted_key_len, 0, 3);
                    fileStream_in.Seek(4, SeekOrigin.Begin);
                    fileStream_in.Read(IV_len, 0, 3);
                }
                catch
                {
                    return null;
                }

                //convert byte array to int
                int encrypted_key_length = BitConverter.ToInt32(encrypted_key_len, 0);
                int IV_length = BitConverter.ToInt32(IV_len, 0);

                // Determine the start position of
                // the cipher text (startC)
                // and its length(lenC).
                int startC = encrypted_key_length + IV_length + 8;
                int lenC = (int)fileStream_in.Length - startC;

                //byte array to store encrypted aes key and IV
                byte[] encrypted_key = new byte[encrypted_key_length];
                byte[] IV = new byte[IV_length];


                // Extract the key and IV
                // starting from index 8
                // after the length values.

                try
                {
                    fileStream_in.Seek(8, SeekOrigin.Begin);
                    fileStream_in.Read(encrypted_key, 0, encrypted_key_length);
                    fileStream_in.Seek(8 + encrypted_key_length, SeekOrigin.Begin);
                    fileStream_in.Read(IV, 0, IV_length);
                }

                catch
                {
                    return null;
                }

                byte[] decryptedAESKey = rsa.Decrypt(encrypted_key, false);
                
                //decrypt the key
                ICryptoTransform transform = aes.CreateDecryptor(decryptedAESKey, IV);

                //decrypt file and write to output path
                FileStream fileStream_out = null;
                try
                {
                    fileStream_out = new FileStream(outputpath, FileMode.Create, FileAccess.Write);
                    int count = 0;
                    int offset = 0;

                    //block size is 1/8 of the aes block size
                    int blockSize = aes.BlockSize / 8;
                    byte[] data = new byte[blockSize];

                    //decrypt a chunk at a time
                    fileStream_in.Seek(startC, SeekOrigin.Begin);
                    CryptoStream cryptoStream = new CryptoStream(fileStream_out, transform, CryptoStreamMode.Write);
                    do
                    {
                        count = fileStream_in.Read(data, 0, blockSize);
                        offset += count;
                        cryptoStream.Write(data, 0, count);
                    }
                    while (count > 0);

                    cryptoStream.FlushFinalBlock();
                }
                catch
                {
                    return null;
                }
                fileStream_in.Close();
                fileStream_out.Close();
                return outputpath;
            });

        }




        //private byte[] Serialize(object obj)
        //{
        //    MemoryStream stream = new MemoryStream();
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    formatter.Serialize(stream, obj);
        //    byte[] data = stream.ToArray();
        //    stream.Close();
        //    return data;

        //}

        //private object Deserialize(byte[] data)
        //{
        //    MemoryStream stream = new MemoryStream(data);
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    object obj = formatter.Deserialize(stream);
        //    stream.Close();
        //    return obj;
        //}

        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        private void ButtonTest_Click(object sender, EventArgs e)
        {
            string output= null;
            EncryptFileAES(TextBoxPathTest.Text,output, rsa);
            MessageBox.Show(output);
        }

        private void ButtonTest2_Click(object sender, EventArgs e)
        {
            string output = null;
            DecryptFileAES(Path.ChangeExtension(TextBoxPathTest.Text, ".enc"), "test.png", output, rsa);
            MessageBox.Show(output);
        }
    }
}
