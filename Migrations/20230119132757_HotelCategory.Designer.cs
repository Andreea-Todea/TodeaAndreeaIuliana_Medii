﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodeaAndreeaIuliana_Medii.Data;

#nullable disable

namespace TodeaAndreeaIuliana_Medii.Migrations
{
    [DbContext(typeof(TodeaAndreeaIuliana_MediiContext))]
    [Migration("20230119132757_HotelCategory")]
    partial class HotelCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TodeaAndreeaIuliana_Medii.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("TodeaAndreeaIuliana_Medii.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("TodeaAndreeaIuliana_Medii.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomNumbers")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("TodeaAndreeaIuliana_Medii.Models.HotelCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("HotelID");

                    b.ToTable("HotelCategory");
                });

            modelBuilder.Entity("TodeaAndreeaIuliana_Medii.Models.Hotel", b =>
                {
                    b.HasOne("TodeaAndreeaIuliana_Medii.Models.Country", "Country")
                        .WithMany("Hotels")
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TodeaAndreeaIuliana_Medii.Models.HotelCategory", b =>
                {
                    b.HasOne("TodeaAndreeaIuliana_Medii.Models.Category", "Category")
                        .WithMany("HotelCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodeaAndreeaIuliana_Medii.Models.Hotel", "Hotel")
                        .WithMany("HotelCategories")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TodeaAndreeaIuliana_Medii.Models.Category", b =>
                {
                    b.Navigation("HotelCategories");
                });

            modelBuilder.Entity("TodeaAndreeaIuliana_Medii.Models.Country", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("TodeaAndreeaIuliana_Medii.Models.Hotel", b =>
                {
                    b.Navigation("HotelCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
