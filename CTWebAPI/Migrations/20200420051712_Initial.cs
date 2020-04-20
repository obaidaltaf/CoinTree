using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CTWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sell = table.Column<string>(nullable: true),
                    buy = table.Column<string>(nullable: true),
                    ask = table.Column<decimal>(nullable: false),
                    bid = table.Column<decimal>(nullable: false),
                    rate = table.Column<decimal>(nullable: false),
                    market = table.Column<string>(nullable: true),
                    timestamp = table.Column<DateTimeOffset>(nullable: true),
                    rateType = table.Column<string>(nullable: true),
                    rateSteps = table.Column<string>(nullable: true),
                    changepercentage = table.Column<decimal>(nullable: false),
                    spotRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoRates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoRates");
        }
    }
}
