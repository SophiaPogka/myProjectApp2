using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleAppMigrations.Migrations
{
    public partial class Customer_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_CustomerId",
                table: "Account",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_CustomerId",
                table: "Account",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_CustomerId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_CustomerId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Account");
        }
    }
}
