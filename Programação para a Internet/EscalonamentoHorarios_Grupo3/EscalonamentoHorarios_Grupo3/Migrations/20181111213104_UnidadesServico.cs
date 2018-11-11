using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalonamentoHorarios_Grupo3.Migrations
{
    public partial class UnidadesServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "UnidadesServico");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "UnidadesServico");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UnidadesServico");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "UnidadesServico",
                newName: "Horario");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UnidadesServico",
                newName: "UnidadesServicoID");

            migrationBuilder.AddColumn<DateTime>(
                name: "AnosServico",
                table: "UnidadesServico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Enfermeiro",
                table: "UnidadesServico",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "UnidadesServico",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Turnos",
                table: "UnidadesServico",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnosServico",
                table: "UnidadesServico");

            migrationBuilder.DropColumn(
                name: "Enfermeiro",
                table: "UnidadesServico");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "UnidadesServico");

            migrationBuilder.DropColumn(
                name: "Turnos",
                table: "UnidadesServico");

            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "UnidadesServico",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "UnidadesServicoID",
                table: "UnidadesServico",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "UnidadesServico",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "UnidadesServico",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UnidadesServico",
                nullable: true);
        }
    }
}
