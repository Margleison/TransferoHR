using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransferoHR.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DNIAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Collaborator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nationality = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DNI = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkEmail = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RG = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostalCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContact = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankBranch = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pixkey = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CNPJ = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JobLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLevel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CollaboratorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    JobTitleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    JobLevelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LeaderId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperience_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkExperience_Collaborator_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Collaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkExperience_JobLevel_JobLevelId",
                        column: x => x.JobLevelId,
                        principalTable: "JobLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkExperience_JobTitle_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "CNPJ", "CreatedAt", "CreatedBy", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1a85ec24-6885-4a04-a938-ba2a02adfe80"), "28.360.810/0001-78", new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5778), "system", "TRANSFERO SWISS LTD", (byte)1, null, null },
                    { new Guid("80badea1-8a9b-475c-a578-24bb1574feca"), "30.934.964/0001-78", new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5776), "system", "TRANSF. GESTÃO DE ATIVOS DIGITAIS - EIRELI", (byte)1, null, null },
                    { new Guid("c30f3588-2b7d-4d1d-b4bb-67e6a37b2190"), "42.155.153/0001-58", new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5780), "system", "TRANSFERO GESTORA DE RECURSOS LTDA", (byte)1, null, null },
                    { new Guid("edd10ad1-aca6-4011-abac-51298e4581df"), "45.685.859/0001-10", new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5782), "system", "TRANSFERO PAGAMENTOS HOLDING", (byte)1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("b857398c-2021-473c-a285-94e05ac802a1"), new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5805), "system", "Infraestrutura", (byte)1, null, null },
                    { new Guid("c52589e8-560c-4af3-a639-430dbcf807f7"), new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5807), "system", "Asset", (byte)1, null, null }
                });

            migrationBuilder.InsertData(
                table: "JobLevel",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("586212e6-c4d3-46d5-afc8-72824616c5d9"), new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5518), "system", "Pleno", (byte)1, null, null },
                    { new Guid("a5c50495-c847-4c06-aa68-acfb459b5d2d"), new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5516), "system", "Senior", (byte)1, null, null },
                    { new Guid("ab9c9975-fe72-4e37-9810-e4c7d9b570b9"), new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5490), "system", "Junior", (byte)1, null, null },
                    { new Guid("e665178f-255a-46bf-9ed6-b05b28a52d17"), new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5564), "system", "Gerente", (byte)1, null, null }
                });

            migrationBuilder.InsertData(
                table: "JobTitle",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1410f0bd-9605-4ead-9e81-73593ec2f1b3"), new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5750), "system", "Desenvolvedor", (byte)1, null, null },
                    { new Guid("518f33ce-f8a4-4d36-bb32-7242601ba01f"), new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5748), "system", "Analista de suporte", (byte)1, null, null },
                    { new Guid("5f47aebe-60cb-46d0-860e-1e34caa82e2a"), new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5746), "system", "DBA", (byte)1, null, null },
                    { new Guid("d0f6f6fb-a287-45a2-be53-a1854316442d"), new DateTime(2024, 11, 7, 13, 59, 37, 414, DateTimeKind.Local).AddTicks(5752), "system", "Analista de Asset", (byte)1, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_CollaboratorId",
                table: "WorkExperience",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_JobLevelId",
                table: "WorkExperience",
                column: "JobLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_JobTitleId",
                table: "WorkExperience",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_LeaderId",
                table: "WorkExperience",
                column: "LeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "WorkExperience");

            migrationBuilder.DropTable(
                name: "Collaborator");

            migrationBuilder.DropTable(
                name: "JobLevel");

            migrationBuilder.DropTable(
                name: "JobTitle");
        }
    }
}
