using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewBank.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BIN = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BIN);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BIN = table.Column<string>(type: "TEXT", nullable: false),
                    ClientId = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_Accounts_Banks_BIN",
                        column: x => x.BIN,
                        principalTable: "Banks",
                        principalColumn: "BIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BIN", "Country", "Name" },
                values: new object[] { "001", "Québec", "Bank of Montreal" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BIN", "Country", "Name" },
                values: new object[] { "815", "Québec", "Caisse Populaire DesJardins" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[] { "1122943", "Bob The Builder" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "BIN", "Balance", "ClientId" },
                values: new object[] { "45jmsh2", "815", 0, "1122943" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "BIN", "Balance", "ClientId" },
                values: new object[] { "smn4592", "001", 0, "1122943" });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BIN",
                table: "Accounts",
                column: "BIN");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
