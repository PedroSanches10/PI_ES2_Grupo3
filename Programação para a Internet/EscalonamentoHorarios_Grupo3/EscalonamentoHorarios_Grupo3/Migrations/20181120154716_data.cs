using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalonamentoHorarios_Grupo3.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Enfermeiros",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Enfermeiros",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
