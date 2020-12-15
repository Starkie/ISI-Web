﻿// <auto-generated />
using System;
using Fotografos.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fotografos.Persistence.Migrations
{
    [DbContext(typeof(FotomixContext))]
    partial class FotomixContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("EquipmentDescription")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("equipmentDescription");

                    b.Property<long?>("PhotographerId")
                        .HasColumnType("INT")
                        .HasColumnName("photographerId");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("resume");

                    b.HasKey("Id");

                    b.ToTable("Application");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Date = new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EquipmentDescription = "Two cameras",
                            PhotographerId = 1L,
                            Resume = "Photographer at a wedding"
                        },
                        new
                        {
                            Id = 2L,
                            Date = new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EquipmentDescription = "Two cameras and tripod",
                            PhotographerId = 2L,
                            Resume = "Nature photographer"
                        });
                });

            modelBuilder.Entity("Fotografos.Domain.Photographer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("address");

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

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "C/Falsa 123",
                            City = "Pueblo Falso",
                            Name = "Juan",
                            Postalcode = 46448L,
                            Surename = "Augusto",
                            Telephone = 456456465L
                        },
                        new
                        {
                            Id = 2L,
                            Address = "C/Falsa 456",
                            City = "Ciudad Falsa",
                            Name = "Carlos",
                            Postalcode = 46444L,
                            Surename = "Murcia",
                            Telephone = 456456464L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
