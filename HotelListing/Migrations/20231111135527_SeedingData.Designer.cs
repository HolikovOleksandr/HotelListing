﻿// <auto-generated />
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelListing.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231111135527_SeedingData")]
    partial class SeedingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelListing.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jamica",
                            ShortName = "JM"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bahamas",
                            ShortName = "BS"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Caiman Island",
                            ShortName = "CI"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ukraine",
                            ShortName = "UA"
                        });
                });

            modelBuilder.Entity("HotelListing.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Raiting")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Negril",
                            CountryId = 1,
                            Name = "Sandals Resort and SPA",
                            Raiting = 4.5
                        },
                        new
                        {
                            Id = 2,
                            Address = "Gearoge Town",
                            CountryId = 3,
                            Name = "Comfort Suites",
                            Raiting = 4.2999999999999998
                        },
                        new
                        {
                            Id = 3,
                            Address = "Nassua",
                            CountryId = 2,
                            Name = "Grand Palladium",
                            Raiting = 4.0
                        },
                        new
                        {
                            Id = 4,
                            Address = "Georgievska",
                            CountryId = 4,
                            Name = "Grand Palladium",
                            Raiting = 3.0
                        });
                });

            modelBuilder.Entity("HotelListing.Models.Hotel", b =>
                {
                    b.HasOne("HotelListing.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
