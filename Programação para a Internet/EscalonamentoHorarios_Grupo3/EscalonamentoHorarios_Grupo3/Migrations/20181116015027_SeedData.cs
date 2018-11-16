using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalonamentoHorarios_Grupo3.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadesServico",
                table: "UnidadesServico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enfermeiro",
                table: "Enfermeiro");

            migrationBuilder.RenameTable(
                name: "UnidadesServico",
                newName: "UnidadesServicos");

            migrationBuilder.RenameTable(
                name: "Enfermeiro",
                newName: "Enfermeiros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadesServicos",
                table: "UnidadesServicos",
                column: "UnidadesServicoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enfermeiros",
                table: "Enfermeiros",
                column: "EnfermeiroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadesServicos",
                table: "UnidadesServicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enfermeiros",
                table: "Enfermeiros");

            migrationBuilder.RenameTable(
                name: "UnidadesServicos",
                newName: "UnidadesServico");

            migrationBuilder.RenameTable(
                name: "Enfermeiros",
                newName: "Enfermeiro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadesServico",
                table: "UnidadesServico",
                column: "UnidadesServicoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enfermeiro",
                table: "Enfermeiro",
                column: "EnfermeiroID");
        }
    }
}
