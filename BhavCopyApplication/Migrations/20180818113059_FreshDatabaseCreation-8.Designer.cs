﻿// <auto-generated />
using System;
using BhavCopyApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BhavCopyApplication.Migrations
{
    [DbContext(typeof(BhavcopyContext))]
    [Migration("20180818113059_FreshDatabaseCreation-8")]
    partial class FreshDatabaseCreation8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("BhavCopyApplication.BhavCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Close");

                    b.Property<double>("High");

                    b.Property<double>("Low");

                    b.Property<double>("Open");

                    b.Property<string>("Ticker");

                    b.Property<double>("Volume");

                    b.Property<DateTime>("date");

                    b.HasKey("Id");

                    b.ToTable("BhavCopies");
                });
#pragma warning restore 612, 618
        }
    }
}
