using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSovos.Infrastructure.Migrations
{
    public partial class TabelaItemPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                schema: "dbo",
                table: "ItemPedido",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                schema: "dbo",
                table: "ItemPedido");
        }
    }
}
