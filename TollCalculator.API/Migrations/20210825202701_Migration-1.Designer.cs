﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TollCalculator.API.Context;

namespace TollCalculator.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210825202701_Migration-1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("TollCalculator.API.Models.LicensePlate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("VehicleTypeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("LicensePlates");
                });

            modelBuilder.Entity("TollCalculator.API.Models.TollEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double?>("Fee")
                        .HasColumnType("REAL");

                    b.Property<Guid?>("LicensePlateId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeOfEntry")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LicensePlateId");

                    b.ToTable("TollEntries");
                });

            modelBuilder.Entity("TollCalculator.API.Models.VehicleType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsTollEligible")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("TollCalculator.API.Models.LicensePlate", b =>
                {
                    b.HasOne("TollCalculator.API.Models.VehicleType", "VehicleType")
                        .WithMany("LicensePlates")
                        .HasForeignKey("VehicleTypeId");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("TollCalculator.API.Models.TollEntry", b =>
                {
                    b.HasOne("TollCalculator.API.Models.LicensePlate", "LicensePlate")
                        .WithMany("TollEntries")
                        .HasForeignKey("LicensePlateId");

                    b.Navigation("LicensePlate");
                });

            modelBuilder.Entity("TollCalculator.API.Models.LicensePlate", b =>
                {
                    b.Navigation("TollEntries");
                });

            modelBuilder.Entity("TollCalculator.API.Models.VehicleType", b =>
                {
                    b.Navigation("LicensePlates");
                });
#pragma warning restore 612, 618
        }
    }
}