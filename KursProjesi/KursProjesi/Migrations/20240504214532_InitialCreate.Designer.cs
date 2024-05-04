﻿// <auto-generated />
using System;
using KursProjesi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KursProjesi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240504214532_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("KursProjesi.Data.Kurs", b =>
                {
                    b.Property<int>("KursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Baslik")
                        .HasColumnType("TEXT");

                    b.Property<int>("OgretmenID")
                        .HasColumnType("INTEGER");

                    b.HasKey("KursId");

                    b.HasIndex("OgretmenID");

                    b.ToTable("Kurslar");
                });

            modelBuilder.Entity("KursProjesi.Data.KursKayit", b =>
                {
                    b.Property<int>("KayitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("KursId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KayitId");

                    b.HasIndex("KursId");

                    b.HasIndex("OgrenciId");

                    b.ToTable("KursKayitlari");
                });

            modelBuilder.Entity("KursProjesi.Data.Ogrenci", b =>
                {
                    b.Property<int>("OgrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Eposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciAdi")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciSoyadi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("OgrenciId");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("KursProjesi.Data.Ogretmen", b =>
                {
                    b.Property<int>("OgretmenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BaslamaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OgretmenID");

                    b.ToTable("Ogretmenler");
                });

            modelBuilder.Entity("KursProjesi.Data.Kurs", b =>
                {
                    b.HasOne("KursProjesi.Data.Ogretmen", "Ogretmen")
                        .WithMany("Kurs")
                        .HasForeignKey("OgretmenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ogretmen");
                });

            modelBuilder.Entity("KursProjesi.Data.KursKayit", b =>
                {
                    b.HasOne("KursProjesi.Data.Kurs", "Kurs")
                        .WithMany("KursKayitlari")
                        .HasForeignKey("KursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KursProjesi.Data.Ogrenci", "Ogrenci")
                        .WithMany("KursKayitlari")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kurs");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("KursProjesi.Data.Kurs", b =>
                {
                    b.Navigation("KursKayitlari");
                });

            modelBuilder.Entity("KursProjesi.Data.Ogrenci", b =>
                {
                    b.Navigation("KursKayitlari");
                });

            modelBuilder.Entity("KursProjesi.Data.Ogretmen", b =>
                {
                    b.Navigation("Kurs");
                });
#pragma warning restore 612, 618
        }
    }
}
