using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BhavCopyApplication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BhavCopies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ticker = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    Open = table.Column<float>(nullable: false),
                    High = table.Column<float>(nullable: false),
                    Low = table.Column<float>(nullable: false),
                    Close = table.Column<float>(nullable: false),
                    Volume = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BhavCopies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BhavCopies");
        }
    }
}
