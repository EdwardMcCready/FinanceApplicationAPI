using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApplicationAPI.DB
{
    /// <inheritdoc />
    public partial class IntialDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar", maxLength: 36, nullable: false),
                    UserName = table.Column<string>(type: "varchar", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<string>(type: "varchar", maxLength: 36, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    TransactionType = table.Column<bool>(type: "integer", maxLength: 1, nullable: false),
                    Type = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    Amount = table.Column<double>(type: "integer", maxLength: 20, nullable: false),
                    UserID = table.Column<string>(type: "varchar", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_User_Transactions",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserID",
                table: "Transactions",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
