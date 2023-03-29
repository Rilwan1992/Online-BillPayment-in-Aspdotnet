using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingPayments.Migrations
{
    public partial class paymentupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDueDate",
                table: "PaymentInstr",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastProcessedDate",
                table: "PaymentInstr",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Payment",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AccountNo",
                table: "Payment",
                column: "AccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BillerId",
                table: "Payment",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CategoryId",
                table: "Payment",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Account_AccountNo",
                table: "Payment",
                column: "AccountNo",
                principalTable: "Account",
                principalColumn: "AccountNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_BillerInfo_BillerId",
                table: "Payment",
                column: "BillerId",
                principalTable: "BillerInfo",
                principalColumn: "BillerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Category_CategoryId",
                table: "Payment",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Account_AccountNo",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_BillerInfo_BillerId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Category_CategoryId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_AccountNo",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_BillerId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CategoryId",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentDueDate",
                table: "PaymentInstr",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "LastProcessedDate",
                table: "PaymentInstr",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentDate",
                table: "Payment",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
