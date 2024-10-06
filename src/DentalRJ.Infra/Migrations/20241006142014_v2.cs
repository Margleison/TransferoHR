using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalRJ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_SomeEntities_CompanyId",
                table: "Clinic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SomeEntities",
                table: "SomeEntities");

            migrationBuilder.RenameTable(
                name: "SomeEntities",
                newName: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_Company_CompanyId",
                table: "Clinic",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_Company_CompanyId",
                table: "Clinic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "SomeEntities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SomeEntities",
                table: "SomeEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_SomeEntities_CompanyId",
                table: "Clinic",
                column: "CompanyId",
                principalTable: "SomeEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
