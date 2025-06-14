﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotatkiWebApp.Data;

#nullable disable

namespace NotatkiWebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NotatkiWebApp.Models.Notatka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataEdycji")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUtworzenia")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kategoria")
                        .HasColumnType("int");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Ulubiona")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Notatkas");
                });
#pragma warning restore 612, 618
        }
    }
}
