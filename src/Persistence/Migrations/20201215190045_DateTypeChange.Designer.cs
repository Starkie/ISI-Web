﻿// <auto-generated />
using System;
using Fotografos.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fotografos.Persistence.Migrations
{
    [DbContext(typeof(FotomixContext))]
    [Migration("20201215190045_DateTypeChange")]
    partial class DateTypeChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Fotografos.Domain.Application", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("date");

                    b.Property<string>("EquimentDescription")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("equimentDescription");

                    b.Property<long?>("PhotographerId")
                        .HasColumnType("INT")
                        .HasColumnName("photographerId");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("resume");

                    b.HasKey("Id");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("Fotografos.Domain.Photographer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Addess")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("addess");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("city");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<long>("Postalcode")
                        .HasColumnType("INT")
                        .HasColumnName("postalcode");

                    b.Property<string>("Surename")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("surename");

                    b.Property<long>("Telephone")
                        .HasColumnType("INT")
                        .HasColumnName("telephone");

                    b.HasKey("Id");

                    b.ToTable("Photographer");
                });
#pragma warning restore 612, 618
        }
    }
}
