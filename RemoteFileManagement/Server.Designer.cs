﻿namespace RemoteFileManagement
{
    partial class Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonListen = new System.Windows.Forms.Button();
            this.RichTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.ButtonTest = new System.Windows.Forms.Button();
            this.ButtonTest2 = new System.Windows.Forms.Button();
            this.TextBoxPathTest = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonListen
            // 
            this.ButtonListen.Location = new System.Drawing.Point(168, 225);
            this.ButtonListen.Name = "ButtonListen";
            this.ButtonListen.Size = new System.Drawing.Size(108, 23);
            this.ButtonListen.TabIndex = 5;
            this.ButtonListen.Text = "Listen";
            this.ButtonListen.UseVisualStyleBackColor = true;
            this.ButtonListen.Click += new System.EventHandler(this.ButtonListen_Click);
            // 
            // RichTextBoxOutput
            // 
            this.RichTextBoxOutput.Location = new System.Drawing.Point(27, 32);
            this.RichTextBoxOutput.Name = "RichTextBoxOutput";
            this.RichTextBoxOutput.Size = new System.Drawing.Size(394, 170);
            this.RichTextBoxOutput.TabIndex = 4;
            this.RichTextBoxOutput.Text = "";
            // 
            // ButtonTest
            // 
            this.ButtonTest.Location = new System.Drawing.Point(27, 225);
            this.ButtonTest.Name = "ButtonTest";
            this.ButtonTest.Size = new System.Drawing.Size(75, 23);
            this.ButtonTest.TabIndex = 6;
            this.ButtonTest.Text = "ButtonTest";
            this.ButtonTest.UseVisualStyleBackColor = true;
            this.ButtonTest.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // ButtonTest2
            // 
            this.ButtonTest2.Location = new System.Drawing.Point(346, 225);
            this.ButtonTest2.Name = "ButtonTest2";
            this.ButtonTest2.Size = new System.Drawing.Size(75, 23);
            this.ButtonTest2.TabIndex = 7;
            this.ButtonTest2.Text = "Test2";
            this.ButtonTest2.UseVisualStyleBackColor = true;
            this.ButtonTest2.Click += new System.EventHandler(this.ButtonTest2_Click);
            // 
            // TextBoxPathTest
            // 
            this.TextBoxPathTest.Location = new System.Drawing.Point(176, 277);
            this.TextBoxPathTest.Name = "TextBoxPathTest";
            this.TextBoxPathTest.Size = new System.Drawing.Size(100, 20);
            this.TextBoxPathTest.TabIndex = 8;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 309);
            this.Controls.Add(this.TextBoxPathTest);
            this.Controls.Add(this.ButtonTest2);
            this.Controls.Add(this.ButtonTest);
            this.Controls.Add(this.ButtonListen);
            this.Controls.Add(this.RichTextBoxOutput);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonListen;
        private System.Windows.Forms.RichTextBox RichTextBoxOutput;
        private System.Windows.Forms.Button ButtonTest;
        private System.Windows.Forms.Button ButtonTest2;
        private System.Windows.Forms.TextBox TextBoxPathTest;
    }
}