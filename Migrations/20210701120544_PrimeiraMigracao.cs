using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uniciv.Api.Migrations
{
    public partial class PrimeiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundosCapital",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorNecessario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataResgate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundosCapital", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundosCapital");
        }
    }
}
