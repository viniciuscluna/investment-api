using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Investment.App.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AvailableAmount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

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
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    InitialPurchaseAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    UpdatedPurchaseAmount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvestments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerInvestments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Customers",
                columns: new[] { "Id", "AvailableAmount", "Name" },
                values: new object[] { new Guid("92a5f228-e11f-4223-9726-9487cf95ab6f"), 5000m, "User 1" });

            migrationBuilder.InsertData(
                table: "FinancialProducts",
                columns: new[] { "Id", "Description", "Enabled", "Expires", "MininumInvestment", "Name", "RiskLevel", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("0e59f5c6-81a1-459d-84bc-2f187f275379"), "LCA Loren Ipsun", true, new DateTime(2024, 6, 29, 4, 24, 15, 370, DateTimeKind.Utc).AddTicks(408), 1000m, "LCA", 5, new DateTime(2024, 6, 23, 4, 24, 15, 370, DateTimeKind.Utc).AddTicks(428) },
                    { new Guid("251c9c19-0053-447a-bb64-06c5926a99d9"), "CDB Loren Ipsun", true, new DateTime(2024, 11, 23, 4, 24, 15, 370, DateTimeKind.Utc).AddTicks(392), 50m, "CDB", 5, new DateTime(2024, 6, 23, 4, 24, 15, 370, DateTimeKind.Utc).AddTicks(400) },
                    { new Guid("ad8dbd67-1d38-4503-8f8f-3a4c82d52aad"), "LCI Loren Ipsun", true, new DateTime(2024, 12, 23, 4, 24, 15, 370, DateTimeKind.Utc).AddTicks(404), 500m, "LCI", 5, new DateTime(2024, 6, 23, 4, 24, 15, 370, DateTimeKind.Utc).AddTicks(405) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvestmentOperations_CustomerInvestmentId",
                table: "CustomerInvestmentOperations",
                column: "CustomerInvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvestments_CustomerId",
                table: "CustomerInvestments",
                column: "CustomerId");

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
                name: "Customers");

            migrationBuilder.DropTable(
                name: "FinancialProducts");
        }
    }
}
