﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransferoHR.Infra.Database;

#nullable disable

namespace TransferoHR.Infra.Migrations
{
    [DbContext(typeof(HRContext))]
    [Migration("20241107165937_DNIAdd")]
    partial class DNIAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TransferoHR.Domain.Entities.Collaborator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("BankBranch")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DNI")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("EmergencyContact")
                        .HasColumnType("longtext");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Nationality")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Pixkey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("WorkEmail")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Collaborator");
                });

            modelBuilder.Entity("TransferoHR.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80badea1-8a9b-475c-a578-24bb1574feca"),
                            CNPJ = "30.934.964/0001-78",
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5776),
                            CreatedBy = "system",
                            Name = "TRANSF. GESTÃO DE ATIVOS DIGITAIS - EIRELI",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("1a85ec24-6885-4a04-a938-ba2a02adfe80"),
                            CNPJ = "28.360.810/0001-78",
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5778),
                            CreatedBy = "system",
                            Name = "TRANSFERO SWISS LTD",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("c30f3588-2b7d-4d1d-b4bb-67e6a37b2190"),
                            CNPJ = "42.155.153/0001-58",
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5780),
                            CreatedBy = "system",
                            Name = "TRANSFERO GESTORA DE RECURSOS LTDA",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("edd10ad1-aca6-4011-abac-51298e4581df"),
                            CNPJ = "45.685.859/0001-10",
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5782),
                            CreatedBy = "system",
                            Name = "TRANSFERO PAGAMENTOS HOLDING",
                            Status = (byte)1
                        });
                });

            modelBuilder.Entity("TransferoHR.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b857398c-2021-473c-a285-94e05ac802a1"),
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5805),
                            CreatedBy = "system",
                            Name = "Infraestrutura",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("c52589e8-560c-4af3-a639-430dbcf807f7"),
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5807),
                            CreatedBy = "system",
                            Name = "Asset",
                            Status = (byte)1
                        });
                });

            modelBuilder.Entity("TransferoHR.Domain.Entities.JobLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("JobLevel");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ab9c9975-fe72-4e37-9810-e4c7d9b570b9"),
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5490),
                            CreatedBy = "system",
                            Name = "Junior",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("a5c50495-c847-4c06-aa68-acfb459b5d2d"),
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5516),
                            CreatedBy = "system",
                            Name = "Senior",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("586212e6-c4d3-46d5-afc8-72824616c5d9"),
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5518),
                            CreatedBy = "system",
                            Name = "Pleno",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("e665178f-255a-46bf-9ed6-b05b28a52d17"),
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5564),
                            CreatedBy = "system",
                            Name = "Gerente",
                            Status = (byte)1
                        });
                });

            modelBuilder.Entity("TransferoHR.Domain.Entities.JobTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("JobTitle");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5f47aebe-60cb-46d0-860e-1e34caa82e2a"),
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5746),
                            CreatedBy = "system",
                            Name = "DBA",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("518f33ce-f8a4-4d36-bb32-7242601ba01f"),
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5748),
                            CreatedBy = "system",
                            Name = "Analista de suporte",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("1410f0bd-9605-4ead-9e81-73593ec2f1b3"),
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5750),
                            CreatedBy = "system",
                            Name = "Desenvolvedor",
                            Status = (byte)1
                        },
                        new
                        {
                            Id = new Guid("d0f6f6fb-a287-45a2-be53-a1854316442d"),
                            CreatedAt = new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5752),
                            CreatedBy = "system",
                            Name = "Analista de Asset",
                            Status = (byte)1
                        });
                });

            modelBuilder.Entity("TransferoHR.Domain.Entities.WorkExperience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CollaboratorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<Guid>("JobLevelId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("JobTitleId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LeaderId")
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CollaboratorId");

                    b.HasIndex("JobLevelId");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("LeaderId");

                    b.ToTable("WorkExperience");
                });

            modelBuilder.Entity("TransferoHR.Domain.Entities.WorkExperience", b =>
                {
                    b.HasOne("TransferoHR.Domain.Entities.Collaborator", "Collaborator")
                        .WithMany()
                        .HasForeignKey("CollaboratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransferoHR.Domain.Entities.JobLevel", "JobLevel")
                        .WithMany()
                        .HasForeignKey("JobLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransferoHR.Domain.Entities.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransferoHR.Domain.Entities.Collaborator", "Leader")
                        .WithMany()
                        .HasForeignKey("LeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collaborator");

                    b.Navigation("JobLevel");

                    b.Navigation("JobTitle");

                    b.Navigation("Leader");
                });
#pragma warning restore 612, 618
        }
    }
}
