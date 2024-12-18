﻿// <auto-generated />
using System;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Migrations
{
    [DbContext(typeof(DataHotelContext))]
    [Migration("20240915214910_Migr")]
    partial class Migr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdminConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Hotel.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConfirmPassword")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Password")
                        .HasColumnType("int");

                    b.Property<int?>("Phone")
                        .HasColumnType("int");

                    b.Property<int?>("RoomsRoomid")
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.HasIndex("RoomsRoomid");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("Hotel.Models.Rooms", b =>
                {
                    b.Property<int>("Roomid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Roomid"));

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Roomdescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roomname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Roomnumber")
                        .HasColumnType("int");

                    b.Property<string>("Roomtype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Roomid");

                    b.HasIndex("AdminId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hotel.Models.Client", b =>
                {
                    b.HasOne("Hotel.Models.Rooms", null)
                        .WithMany("clients")
                        .HasForeignKey("RoomsRoomid");
                });

            modelBuilder.Entity("Hotel.Models.Rooms", b =>
                {
                    b.HasOne("Hotel.Models.Admin", null)
                        .WithMany("Rooms")
                        .HasForeignKey("AdminId");
                });

            modelBuilder.Entity("Hotel.Models.Admin", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Hotel.Models.Rooms", b =>
                {
                    b.Navigation("clients");
                });
#pragma warning restore 612, 618
        }
    }
}
