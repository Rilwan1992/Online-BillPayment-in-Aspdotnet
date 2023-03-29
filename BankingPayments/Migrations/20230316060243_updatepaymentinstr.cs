using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingPayments.Migrations
{
    public partial class updatepaymentinstr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillerInfo_AspNetUsers_CustomerId",
                table: "BillerInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_BillerInfo_Category_CategoryId",
                table: "BillerInfo");

            migrationBuilder.DropIndex(
                name: "IX_BillerInfo_CategoryId",
                table: "BillerInfo");

            migrationBuilder.DropIndex(
                name: "IX_BillerInfo_CustomerId",
                table: "BillerInfo");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInstr_AccountNo",
                table: "PaymentInstr",
                column: "AccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInstr_BillerId",
                table: "PaymentInstr",
                column: "BillerId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_BillerInfo_CategoryId",
                table: "BillerInfo",
                column: "CategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BillerInfo_Category_CategoryId",
                table: "BillerInfo",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
