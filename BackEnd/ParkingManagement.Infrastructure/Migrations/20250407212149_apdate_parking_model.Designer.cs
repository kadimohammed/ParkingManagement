﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingManagement.Infrastructure.Persistance.Data;

#nullable disable

namespace ParkingManagement.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250407212149_apdate_parking_model")]
    partial class apdate_parking_model
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkingManagement.Core.Entities.ArtisanClientService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtisanId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ParkingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtisanId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ParkingId");

                    b.ToTable("ArtisanClientServices");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ArtisanImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtisanId")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtisanId");

                    b.HasIndex("ImageId");

                    b.ToTable("ArtisanImages");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ArtisanType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArtisanTypes");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ArtisanWorkDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtisanId")
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtisanId");

                    b.ToTable("ArtisanWorkDays");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ClientParking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePark")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientParkings");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("NomParcking")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Surface")
                        .HasColumnType("float");

                    b.Property<TimeOnly>("TimeEndWork")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("TimeStartWork")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("parkings");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ParkingDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("ParkingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParkingId");

                    b.ToTable("ParkingDays");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.Admin", b =>
                {
                    b.HasBaseType("ParkingManagement.Core.Entities.User");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.ToTable("Users", t =>
                        {
                            t.Property("Rating")
                                .HasColumnName("Admin_Rating");
                        });

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.Artisan", b =>
                {
                    b.HasBaseType("ParkingManagement.Core.Entities.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArtisanTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("TrailerUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasIndex("ArtisanTypeId");

                    b.ToTable("Users", t =>
                        {
                            t.Property("Address")
                                .HasColumnName("Artisan_Address");

                            t.Property("IsActive")
                                .HasColumnName("Artisan_IsActive");
                        });

                    b.HasDiscriminator().HasValue("Artisan");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.Client", b =>
                {
                    b.HasBaseType("ParkingManagement.Core.Entities.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ArtisanClientService", b =>
                {
                    b.HasOne("ParkingManagement.Core.Entities.Artisan", "Artisan")
                        .WithMany("ArtisanClientServices")
                        .HasForeignKey("ArtisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingManagement.Core.Entities.Client", "Client")
                        .WithMany("ArtisanClientServices")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingManagement.Core.Entities.Parking", "Parking")
                        .WithMany("artisanClientServices")
                        .HasForeignKey("ParkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artisan");

                    b.Navigation("Client");

                    b.Navigation("Parking");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ArtisanImage", b =>
                {
                    b.HasOne("ParkingManagement.Core.Entities.Artisan", "Artisan")
                        .WithMany("ArtisanImages")
                        .HasForeignKey("ArtisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingManagement.Core.Entities.Image", "Image")
                        .WithMany("ArtisanImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artisan");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ArtisanWorkDay", b =>
                {
                    b.HasOne("ParkingManagement.Core.Entities.Artisan", "Artisan")
                        .WithMany("ArtisanWorkDays")
                        .HasForeignKey("ArtisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artisan");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ClientParking", b =>
                {
                    b.HasOne("ParkingManagement.Core.Entities.Client", "Client")
                        .WithMany("ClientParkings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ParkingDay", b =>
                {
                    b.HasOne("ParkingManagement.Core.Entities.Parking", "Parking")
                        .WithMany("ParkingDays")
                        .HasForeignKey("ParkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parking");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.Artisan", b =>
                {
                    b.HasOne("ParkingManagement.Core.Entities.ArtisanType", "Type")
                        .WithMany("Artisans")
                        .HasForeignKey("ArtisanTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.ArtisanType", b =>
                {
                    b.Navigation("Artisans");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.Image", b =>
                {
                    b.Navigation("ArtisanImages");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.Parking", b =>
                {
                    b.Navigation("ParkingDays");

                    b.Navigation("artisanClientServices");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.Artisan", b =>
                {
                    b.Navigation("ArtisanClientServices");

                    b.Navigation("ArtisanImages");

                    b.Navigation("ArtisanWorkDays");
                });

            modelBuilder.Entity("ParkingManagement.Core.Entities.Client", b =>
                {
                    b.Navigation("ArtisanClientServices");

                    b.Navigation("ClientParkings");
                });
#pragma warning restore 612, 618
        }
    }
}
