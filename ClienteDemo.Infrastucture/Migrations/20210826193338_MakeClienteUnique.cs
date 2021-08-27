using Microsoft.EntityFrameworkCore.Migrations;

namespace ClienteDemo.Infrastructure.Migrations
{
    public partial class MakeClienteUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "Cliente",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cliente",
                table: "Clientes",
                column: "Cliente",
                unique: true,
                filter: "[Cliente] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_Cliente",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "Cliente",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
