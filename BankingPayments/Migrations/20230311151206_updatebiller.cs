using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingPayments.Migrations
{
    public partial class updatebiller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInstr_Account_AccountNo",
                table: "PaymentInstr");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInstr_BillerInfo_BillerId",
                table: "PaymentInstr");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInstr_AccountNo",
                table: "PaymentInstr");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInstr_BillerId",
                table: "PaymentInstr");

            migrationBuilder.DropIndex(
                name: "IX_Payment_AccountNo",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_BillerId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CategoryId",
                table: "Payment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PaymentInstr_AccountNo",
                table: "PaymentInstr",
                column: "AccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInstr_BillerId",
                table: "PaymentInstr",
                column: "BillerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentInstr_Account_AccountNo",
                table: "PaymentInstr",
                column: "AccountNo",
                principalTable: "Account",
                principalColumn: "AccountNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentInstr_BillerInfo_BillerId",
                table: "PaymentInstr",
                column: "BillerId",
                principalTable: "BillerInfo",
                principalColumn: "BillerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
