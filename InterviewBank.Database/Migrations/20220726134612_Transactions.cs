using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewBank.Database.Migrations
{
    public partial class Transactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BIN",
                keyValue: "001");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsFlagged = table.Column<bool>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BIN", "Country", "Name" },
                values: new object[] { "004", "Canada", "Toronto Dominion" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: "smn4592",
                column: "BIN",
                value: "004");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountNumber",
                table: "Transactions",
                column: "AccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BIN",
                keyValue: "004");

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BIN", "Country", "Name" },
                values: new object[] { "001", "Québec", "Bank of Montreal" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: "smn4592",
                column: "BIN",
                value: "001");
        }
    }
}
