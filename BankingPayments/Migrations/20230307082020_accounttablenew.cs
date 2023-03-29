using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingPayments.Migrations
{
    public partial class accounttablenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Account");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
