﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server_API.DBContext;

#nullable disable

namespace Server_API.Migrations.TrainDB
{
    [DbContext(typeof(TrainDBContext))]
    [Migration("20240523164311_Train6")]
    partial class Train6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("Server_API.Models.DiemDi", b =>
                {
                    b.Property<string>("ID_Tuyen")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("ID_Tram")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<float>("KhoangCach")
                        .HasColumnType("REAL");

                    b.HasKey("ID_Tuyen", "ID_Tram");

                    b.HasIndex("ID_Tram");

                    b.ToTable("DiemDi", (string)null);
                });

            modelBuilder.Entity("Server_API.Models.Ghe", b =>
                {
                    b.Property<string>("ID_Ghe")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("ID_Toa")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("ID_Ghe", "ID_Toa");

                    b.HasIndex("ID_Ghe")
                        .IsUnique();

                    b.HasIndex("ID_Toa");

                    b.ToTable("Ghe", (string)null);
                });

            modelBuilder.Entity("Server_API.Models.Giuong", b =>
                {
                    b.Property<string>("ID_Giuong")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("ID_Phong")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("ID_Giuong", "ID_Phong");

                    b.HasIndex("ID_Giuong")
                        .IsUnique();

                    b.HasIndex("ID_Phong");

                    b.ToTable("Giuong", (string)null);
                });

            modelBuilder.Entity("Server_API.Models.LichTrinh", b =>
                {
                    b.Property<string>("ID_LichTrinh")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<int>("Chieu")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("Gio")
                        .HasColumnType("TEXT");

                    b.Property<string>("ID_Tau")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("ID_Tuyen")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Thu")
                        .HasColumnType("TEXT");

                    b.HasKey("ID_LichTrinh");

                    b.HasIndex("ID_Tau");

                    b.HasIndex("ID_Tuyen");

                    b.ToTable("LichTrinh", (string)null);
                });

            modelBuilder.Entity("Server_API.Models.Phong", b =>
                {
                    b.Property<string>("ID_Phong")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("ID_Toa")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("ID_Phong");

                    b.HasIndex("ID_Toa");

                    b.ToTable("Phong", (string)null);
                });

            modelBuilder.Entity("Server_API.Models.Tau", b =>
                {
                    b.Property<string>("ID_Tau")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Lop")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TuoiTho")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TuyenID_Tuyen")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID_Tau");

                    b.HasIndex("TuyenID_Tuyen");

                    b.ToTable("Tau", (string)null);
                });

            modelBuilder.Entity("Server_API.Models.Toa", b =>
                {
                    b.Property<string>("ID_Toa")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("ID_Tau")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Loai")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("ID_Toa");

                    b.HasIndex("ID_Tau");

                    b.ToTable("Toa", (string)null);
                });

            modelBuilder.Entity("Server_API.Models.Tram", b =>
                {
                    b.Property<string>("ID_Tram")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("TenTram")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Thanhpho")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Tinh")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("ID_Tram");

                    b.ToTable("Tram", (string)null);
                });

            modelBuilder.Entity("Server_API.Models.Tuyen", b =>
                {
                    b.Property<string>("ID_Tuyen")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("TenTuyen")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.HasKey("ID_Tuyen");

                    b.ToTable("Tuyen", (string)null);
                });

            modelBuilder.Entity("Server_API.Models.VeNam", b =>
                {
                    b.Property<string>("ID_VeNam")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("DonGia")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("ID_Giuong")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("ID_Tuyen")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<int>("KhaDung")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("NamSinh")
                        .HasColumnType("TEXT");

                    b.HasKey("ID_VeNam");

                    b.ToTable("VeNam", (string)null);
                });

            modelBuilder.Entity("Server_API.Models.VeNgoi", b =>
                {
                    b.Property<string>("ID_VeNgoi")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("DonGia")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("ID_Ghe")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("ID_Tuyen")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<int>("KhaDung")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("NamSinh")
                        .HasColumnType("TEXT");

                    b.HasKey("ID_VeNgoi");

                    b.ToTable("VeNgoi", (string)null);
                });

            modelBuilder.Entity("Server_API.Models.DiemDi", b =>
                {
                    b.HasOne("Server_API.Models.Tram", "Tram")
                        .WithMany("DiemDi")
                        .HasForeignKey("ID_Tram")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server_API.Models.Tuyen", "Tuyen")
                        .WithMany("DiemDi")
                        .HasForeignKey("ID_Tuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tram");

                    b.Navigation("Tuyen");
                });

            modelBuilder.Entity("Server_API.Models.Ghe", b =>
                {
                    b.HasOne("Server_API.Models.VeNgoi", "VeNgoi")
                        .WithOne("Ghe")
                        .HasForeignKey("Server_API.Models.Ghe", "ID_Ghe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server_API.Models.Toa", "Toa")
                        .WithMany("Ghe")
                        .HasForeignKey("ID_Toa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Toa");

                    b.Navigation("VeNgoi");
                });

            modelBuilder.Entity("Server_API.Models.Giuong", b =>
                {
                    b.HasOne("Server_API.Models.VeNam", "VeNam")
                        .WithOne("Giuong")
                        .HasForeignKey("Server_API.Models.Giuong", "ID_Giuong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server_API.Models.Phong", "Phong")
                        .WithMany("Giuong")
                        .HasForeignKey("ID_Phong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phong");

                    b.Navigation("VeNam");
                });

            modelBuilder.Entity("Server_API.Models.LichTrinh", b =>
                {
                    b.HasOne("Server_API.Models.Tau", "Tau")
                        .WithMany("LichTrinh")
                        .HasForeignKey("ID_Tau")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server_API.Models.Tuyen", "Tuyen")
                        .WithMany("LichTrinh")
                        .HasForeignKey("ID_Tuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tau");

                    b.Navigation("Tuyen");
                });

            modelBuilder.Entity("Server_API.Models.Phong", b =>
                {
                    b.HasOne("Server_API.Models.Toa", "Toa")
                        .WithMany("Phong")
                        .HasForeignKey("ID_Toa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Toa");
                });

            modelBuilder.Entity("Server_API.Models.Tau", b =>
                {
                    b.HasOne("Server_API.Models.Tuyen", "Tuyen")
                        .WithMany()
                        .HasForeignKey("TuyenID_Tuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tuyen");
                });

            modelBuilder.Entity("Server_API.Models.Toa", b =>
                {
                    b.HasOne("Server_API.Models.Tau", "Tau")
                        .WithMany("Toa")
                        .HasForeignKey("ID_Tau")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tau");
                });

            modelBuilder.Entity("Server_API.Models.Phong", b =>
                {
                    b.Navigation("Giuong");
                });

            modelBuilder.Entity("Server_API.Models.Tau", b =>
                {
                    b.Navigation("LichTrinh");

                    b.Navigation("Toa");
                });

            modelBuilder.Entity("Server_API.Models.Toa", b =>
                {
                    b.Navigation("Ghe");

                    b.Navigation("Phong");
                });

            modelBuilder.Entity("Server_API.Models.Tram", b =>
                {
                    b.Navigation("DiemDi");
                });

            modelBuilder.Entity("Server_API.Models.Tuyen", b =>
                {
                    b.Navigation("DiemDi");

                    b.Navigation("LichTrinh");
                });

            modelBuilder.Entity("Server_API.Models.VeNam", b =>
                {
                    b.Navigation("Giuong")
                        .IsRequired();
                });

            modelBuilder.Entity("Server_API.Models.VeNgoi", b =>
                {
                    b.Navigation("Ghe")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
