using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingPayments.Migrations
{
    public partial class udpatepaymantinstr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillerInfo_AspNetUsers_CustomerId",
                table: "BillerInfo");

            migrationBuilder.DropIndex(
                name: "IX_BillerInfo_CustomerId",
                table: "BillerInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BillerInfo_CustomerId",
                table: "BillerInfo",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillerInfo_AspNetUsers_CustomerId",
                table: "BillerInfo",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
