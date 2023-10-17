using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApplication.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionDBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StartingPrice = table.Column<int>(type: "int", nullable: false),
                    ClosingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BidDBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidDBs_AuctionDBs_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuctionDBs",
                columns: new[] { "Id", "ClosingTime", "Description", "Name", "StartingPrice", "UserName" },
                values: new object[] { -1, new DateTime(2023, 10, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), "En test auktion", "Test", 100, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_BidDBs_AuctionId",
                table: "BidDBs",
                column: "AuctionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidDBs");

            migrationBuilder.DropTable(
                name: "AuctionDBs");
        }
    }
}
