using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalonamentoHorarios_Grupo3.Migrations
{
    public partial class EnfermeiroController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Enfermeiros");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Enfermeiros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Enfermeiros",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Enfermeiros",
                maxLength: 100,
                nullable: true);
        }
    }
}
