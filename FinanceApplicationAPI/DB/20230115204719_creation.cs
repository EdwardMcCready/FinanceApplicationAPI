using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApplicationAPI.DB
{
    /// <inheritdoc />
    public partial class creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar", maxLength: 36, nullable: false),
                    UserName = table.Column<string>(type: "varchar", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionName",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionName", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar", maxLength: 36, nullable: false),
                    Type = table.Column<string>(type: "varchar", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar", maxLength: 36, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", maxLength: 50, nullable: false),
                    FlowType = table.Column<bool>(type: "integer", maxLength: 1, nullable: false),
                    Amount = table.Column<double>(type: "integer", maxLength: 20, nullable: false),
                    TransactionNameID = table.Column<string>(type: "varchar", maxLength: 36, nullable: true),
                    TransactionTypeID = table.Column<string>(type: "varchar", maxLength: 36, nullable: true),
                    AccountID = table.Column<string>(type: "varchar", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Account_Transactions",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Name",
                        column: x => x.TransactionNameID,
                        principalTable: "TransactionName",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Transaction_Type",
                        column: x => x.TransactionTypeID,
                        principalTable: "TransactionType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionNameID",
                table: "Transactions",
                column: "TransactionNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeID",
                table: "Transactions",
                column: "TransactionTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "TransactionName");

            migrationBuilder.DropTable(
                name: "TransactionType");
        }
    }
}
