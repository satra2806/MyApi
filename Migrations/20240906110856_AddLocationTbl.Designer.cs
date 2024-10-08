﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApi.Models;

#nullable disable

namespace MyApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240906110856_AddLocationTbl")]
    partial class AddLocationTbl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Airport")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CCC")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FacType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LocID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SDPFacType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SDPLocID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SSC")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceArea")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("locationTbl");
                });

            modelBuilder.Entity("MyApi.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Assumptions")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Benefits")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Constraints")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OriginatorROM")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProblemStatement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProcessType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProposedSolution")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
