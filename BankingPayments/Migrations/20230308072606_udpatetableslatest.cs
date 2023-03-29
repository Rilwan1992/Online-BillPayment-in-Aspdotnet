using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingPayments.Migrations
{
    public partial class udpatetableslatest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountModelAccountNo",
                table: "PaymentInstr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountModelAccountNo",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryModelCategoryId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryModelCategoryId",
                table: "BillerInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInstr_AccountModelAccountNo",
                table: "PaymentInstr",
                column: "AccountModelAccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInstr_BillerId",
                table: "PaymentInstr",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AccountModelAccountNo",
                table: "Payment",
                column: "AccountModelAccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BillerId",
                table: "Payment",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CategoryModelCategoryId",
                table: "Payment",
                column: "CategoryModelCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BillerInfo_CategoryModelCategoryId",
                table: "BillerInfo",
                column: "CategoryModelCategoryId");

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
                name: "FK_BillerInfo_Category_CategoryModelCategoryId",
                table: "BillerInfo",
                column: "CategoryModelCategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Account_AccountModelAccountNo",
                table: "Payment",
                column: "AccountModelAccountNo",
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
                name: "FK_Payment_Category_CategoryModelCategoryId",
                table: "Payment",
                column: "CategoryModelCategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentInstr_Account_AccountModelAccountNo",
                table: "PaymentInstr",
                column: "AccountModelAccountNo",
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
                name: "FK_BillerInfo_AspNetUsers_CustomerId",
                table: "BillerInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_BillerInfo_Category_CategoryModelCategoryId",
                table: "BillerInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Account_AccountModelAccountNo",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_BillerInfo_BillerId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Category_CategoryModelCategoryId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInstr_Account_AccountModelAccountNo",
                table: "PaymentInstr");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInstr_BillerInfo_BillerId",
                table: "PaymentInstr");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInstr_AccountModelAccountNo",
                table: "PaymentInstr");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInstr_BillerId",
                table: "PaymentInstr");

            migrationBuilder.DropIndex(
                name: "IX_Payment_AccountModelAccountNo",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_BillerId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CategoryModelCategoryId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_BillerInfo_CategoryModelCategoryId",
                table: "BillerInfo");

            migrationBuilder.DropIndex(
                name: "IX_BillerInfo_CustomerId",
                table: "BillerInfo");

            migrationBuilder.DropColumn(
                name: "AccountModelAccountNo",
                table: "PaymentInstr");

            migrationBuilder.DropColumn(
                name: "AccountModelAccountNo",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CategoryModelCategoryId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CategoryModelCategoryId",
                table: "BillerInfo");
        }
    }
}
