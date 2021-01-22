﻿// <auto-generated />
using System;
using App.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20210121234437_UserMigration")]
    partial class UserMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("App.Domain.Models.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11) CHARACTER SET utf8mb4")
                        .HasMaxLength(11);

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("varchar(1) CHARACTER SET utf8mb4")
                        .HasMaxLength(1);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}
