using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingPayments.Migrations
{
    public partial class updatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillerInfo_Category_CategoryModelCategoryId",
                table: "BillerInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Account_AccountModelAccountNo",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Category_CategoryModelCategoryId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInstr_Account_AccountModelAccountNo",
                table: "PaymentInstr");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInstr_AccountModelAccountNo",
                table: "PaymentInstr");

            migrationBuilder.DropIndex(
                name: "IX_Payment_AccountModelAccountNo",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CategoryModelCategoryId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_BillerInfo_CategoryModelCategoryId",
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

            migrationBuilder.DropColumn(
                name: "BillPayRegistered",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BillPayprefered",
                table: "Account");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInstr_AccountNo",
                table: "PaymentInstr",
                column: "AccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AccountNo",
                table: "Payment",
                column: "AccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CategoryId",
                table: "Payment",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BillerInfo_CategoryId",
                table: "BillerInfo",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillerInfo_Category_CategoryId",
                table: "BillerInfo",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Account_AccountNo",
                table: "Payment",
                column: "AccountNo",
                principalTable: "Account",
                principalColumn: "AccountNo",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillerInfo_Category_CategoryId",
                table: "BillerInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Account_AccountNo",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Category_CategoryId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInstr_Account_AccountNo",
                table: "PaymentInstr");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInstr_AccountNo",
                table: "PaymentInstr");

            migrationBuilder.DropIndex(
                name: "IX_Payment_AccountNo",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CategoryId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_BillerInfo_CategoryId",
                table: "BillerInfo");

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

            migrationBuilder.AddColumn<string>(
                name: "BillPayRegistered",
                table: "AspNetUsers",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillPayprefered",
                table: "Account",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInstr_AccountModelAccountNo",
                table: "PaymentInstr",
                column: "AccountModelAccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AccountModelAccountNo",
                table: "Payment",
                column: "AccountModelAccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CategoryModelCategoryId",
                table: "Payment",
                column: "CategoryModelCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BillerInfo_CategoryModelCategoryId",
                table: "BillerInfo",
                column: "CategoryModelCategoryId");

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
        }
    }
}
