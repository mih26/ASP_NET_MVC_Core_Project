﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectMVCcore.Models;

#nullable disable

namespace ProjectMVCcore.Migrations
{
    [DbContext(typeof(SmartphoneDbContext))]
    partial class SmartphoneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectMVCcore.Models.Configuration", b =>
                {
                    b.Property<int>("ConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConfigurationId"));

                    b.Property<string>("BrandValue")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConfigurationDetails")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("SmartphoneId")
                        .HasColumnType("int");

                    b.HasKey("ConfigurationId");

                    b.HasIndex("SmartphoneId");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("ProjectMVCcore.Models.Smartphone", b =>
                {
                    b.Property<int>("SmartphoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SmartphoneId"));

                    b.Property<bool>("Instock")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("date");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("SmartphoneModel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SmartphoneId");

                    b.ToTable("Smartphones");
                });

            modelBuilder.Entity("ProjectMVCcore.Models.Configuration", b =>
                {
                    b.HasOne("ProjectMVCcore.Models.Smartphone", "Smartphone")
                        .WithMany("Configurations")
                        .HasForeignKey("SmartphoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Smartphone");
                });

            modelBuilder.Entity("ProjectMVCcore.Models.Smartphone", b =>
                {
                    b.Navigation("Configurations");
                });
#pragma warning restore 612, 618
        }
    }
}