using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class BidDBs_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BidDBs",
                columns: new[] { "Id", "AuctionId", "CreatedDate", "Price", "UserName" },
                values: new object[,]
                {
                    { -2, -1, new DateTime(2023, 10, 17, 11, 39, 2, 586, DateTimeKind.Local).AddTicks(8424), 1000, "admin" },
                    { -1, -1, new DateTime(2023, 10, 17, 11, 39, 2, 586, DateTimeKind.Local).AddTicks(8385), 500, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
