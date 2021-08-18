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
    [Migration("20210818203941_Migration-1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("TollCalculator.API.Models.TollEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("Fee")
                        .HasColumnType("REAL");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeOfEntry")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TollEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
