using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApplication.Migrations
{
    public partial class AuctionDb_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "UserName",
                value: "pellebe@kth.se");

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedDate", "UserName" },
                values: new object[] { new DateTime(2023, 10, 18, 10, 58, 6, 910, DateTimeKind.Local).AddTicks(5175), "pellebe@kth.se" });

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "UserName" },
                values: new object[] { new DateTime(2023, 10, 18, 10, 58, 6, 910, DateTimeKind.Local).AddTicks(5137), "pellebe@kth.se" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "UserName",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedDate", "UserName" },
                values: new object[] { new DateTime(2023, 10, 17, 11, 39, 2, 586, DateTimeKind.Local).AddTicks(8424), "admin" });

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "UserName" },
                values: new object[] { new DateTime(2023, 10, 17, 11, 39, 2, 586, DateTimeKind.Local).AddTicks(8385), "admin" });
        }
    }
}
