using Microsoft.EntityFrameworkCore.Migrations;

namespace Uniciv.Api.Migrations
{
    public partial class TerceiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Investidor",
                table: "Investidor");

            migrationBuilder.RenameTable(
                name: "Investidor",
                newName: "Investidores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investidores",
                table: "Investidores",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Investidores",
                table: "Investidores");

            migrationBuilder.RenameTable(
                name: "Investidores",
                newName: "Investidor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investidor",
                table: "Investidor",
                column: "Id");
        }
    }
}
