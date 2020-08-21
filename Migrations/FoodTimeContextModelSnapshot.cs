﻿// <auto-generated />
using System;
using FoodTime.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodTime.API.Migrations
{
    [DbContext(typeof(FoodTimeContext))]
    partial class FoodTimeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodTime.API.Data.Models.Pastry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PastryFillingId")
                        .HasColumnType("int");

                    b.Property<int>("PastryTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PastryTypeId");

                    b.HasIndex("PastryFillingId", "PastryTypeId");

                    b.ToTable("Pastry");
                });

            modelBuilder.Entity("FoodTime.API.Data.Models.PastryFilling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("PastryFilling");
                });

            modelBuilder.Entity("FoodTime.API.Data.Models.PastryStock", b =>
                {
                    b.Property<int>("PastryFillingId")
                        .HasColumnType("int");

                    b.Property<int>("PastryTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("PastryFillingId", "PastryTypeId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("PastryTypeId");

                    b.ToTable("PastryStock");
                });

            modelBuilder.Entity("FoodTime.API.Data.Models.PastryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("PastryType");
                });

            modelBuilder.Entity("FoodTime.API.Data.Models.Pastry", b =>
                {
                    b.HasOne("FoodTime.API.Data.Models.PastryFilling", "PastryFilling")
                        .WithMany()
                        .HasForeignKey("PastryFillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodTime.API.Data.Models.PastryType", "PastryType")
                        .WithMany()
                        .HasForeignKey("PastryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodTime.API.Data.Models.PastryStock", b =>
                {
                    b.HasOne("FoodTime.API.Data.Models.PastryFilling", "PastryFilling")
                        .WithMany()
                        .HasForeignKey("PastryFillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodTime.API.Data.Models.PastryType", "PastryType")
                        .WithMany()
                        .HasForeignKey("PastryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
