using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalonamentoHorarios_Grupo3.Migrations
{
    public partial class Enfermeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cellphone",
                table: "Enfermeiro");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Enfermeiro");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Enfermeiro",
                newName: "Telemovel");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Enfermeiro",
                newName: "Morada");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Enfermeiro",
                newName: "CodPostal");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Enfermeiro",
                newName: "EnfermeiroID");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Enfermeiro",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Enfermeiro",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataNascimento",
                table: "Enfermeiro",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NIF",
                table: "Enfermeiro",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Enfermeiro",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Enfermeiro",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnidadeServico",
                table: "Enfermeiro",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Enfermeiro");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Enfermeiro");

            migrationBuilder.DropColumn(
                name: "NIF",
                table: "Enfermeiro");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Enfermeiro");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Enfermeiro");

            migrationBuilder.DropColumn(
                name: "UnidadeServico",
                table: "Enfermeiro");

            migrationBuilder.RenameColumn(
                name: "Telemovel",
                table: "Enfermeiro",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Morada",
                table: "Enfermeiro",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CodPostal",
                table: "Enfermeiro",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "EnfermeiroID",
                table: "Enfermeiro",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Enfermeiro",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Cellphone",
                table: "Enfermeiro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Enfermeiro",
                nullable: true);
        }
    }
}
