﻿// <auto-generated />
using System;
using KamasutraAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KamasutraAPI.Migrations
{
    [DbContext(typeof(KamasutraContext))]
    [Migration("20220629033636_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KamasutraAPI.Models.BodyPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BodyPart");
                });

            modelBuilder.Entity("KamasutraAPI.Models.KamasutraAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("KamasutraAPI.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActionId")
                        .HasColumnType("integer");

                    b.Property<int?>("BodyPartId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("BodyPartId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("KamasutraAPI.Models.Position", b =>
                {
                    b.HasOne("KamasutraAPI.Models.KamasutraAction", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.HasOne("KamasutraAPI.Models.BodyPart", "BodyPart")
                        .WithMany()
                        .HasForeignKey("BodyPartId");

                    b.Navigation("Action");

                    b.Navigation("BodyPart");
                });
#pragma warning restore 612, 618
        }
    }
}