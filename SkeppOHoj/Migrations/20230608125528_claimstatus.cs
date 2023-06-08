using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkeppOHoj.Migrations
{
    /// <inheritdoc />
    public partial class claimstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "ClaimStatus");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "InsuranceType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaimStatus",
                table: "ClaimStatus",
                column: "ClaimStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaimStatus",
                table: "ClaimStatus");

            migrationBuilder.RenameTable(
                name: "ClaimStatus",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "InsuranceType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "ClaimStatusId");
        }
    }
}
