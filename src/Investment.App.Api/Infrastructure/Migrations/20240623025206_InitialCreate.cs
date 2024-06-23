using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Investment.App.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    RiskLevel = table.Column<int>(type: "integer", nullable: false),
                    MininumInvestment = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInvestments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FinancialProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    InitialPurchaseAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    UpdatedPurchaseAmount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvestments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerInvestments_FinancialProducts_FinancialProductId",
                        column: x => x.FinancialProductId,
                        principalTable: "FinancialProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInvestmentOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerInvestmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvestmentOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerInvestmentOperations_CustomerInvestments_CustomerIn~",
                        column: x => x.CustomerInvestmentId,
                        principalTable: "CustomerInvestments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FinancialProducts",
                columns: new[] { "Id", "Description", "Enabled", "Expires", "MininumInvestment", "Name", "RiskLevel", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("03d1c4ed-160c-47e3-8519-de0e37fc2fd7"), "LCA Loren Ipsun", true, new DateTime(2024, 6, 29, 2, 52, 6, 20, DateTimeKind.Utc).AddTicks(2623), 1000m, "LCA", 5, new DateTime(2024, 6, 23, 2, 52, 6, 20, DateTimeKind.Utc).AddTicks(2639) },
                    { new Guid("5314c8d1-77f8-4650-b60d-e759b8a082ab"), "LCI Loren Ipsun", true, new DateTime(2024, 12, 23, 2, 52, 6, 20, DateTimeKind.Utc).AddTicks(2471), 500m, "LCI", 5, new DateTime(2024, 6, 23, 2, 52, 6, 20, DateTimeKind.Utc).AddTicks(2472) },
                    { new Guid("e90ec31a-2474-4116-bc26-6a702b450b85"), "CDB Loren Ipsun", true, new DateTime(2024, 11, 23, 2, 52, 6, 20, DateTimeKind.Utc).AddTicks(2458), 50m, "CDB", 5, new DateTime(2024, 6, 23, 2, 52, 6, 20, DateTimeKind.Utc).AddTicks(2468) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvestmentOperations_CustomerInvestmentId",
                table: "CustomerInvestmentOperations",
                column: "CustomerInvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvestments_FinancialProductId",
                table: "CustomerInvestments",
                column: "FinancialProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInvestmentOperations");

            migrationBuilder.DropTable(
                name: "CustomerInvestments");

            migrationBuilder.DropTable(
                name: "FinancialProducts");
        }
    }
}
