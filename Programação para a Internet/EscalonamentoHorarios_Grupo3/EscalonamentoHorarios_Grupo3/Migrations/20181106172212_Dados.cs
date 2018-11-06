using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalonamentoHorarios_Grupo3.Migrations
{
    public partial class Dados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Enfermeiro");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Enfermeiro",
                newName: "Street");

            migrationBuilder.AddColumn<int>(
                name: "Cellphone",
                table: "Enfermeiro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Enfermeiro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Enfermeiro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Enfermeiro",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cellphone",
                table: "Enfermeiro");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Enfermeiro");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Enfermeiro");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Enfermeiro");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Enfermeiro",
                newName: "Title");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Enfermeiro",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
