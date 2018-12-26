using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalonamentoHorarios_Grupo3.Migrations.EscalonamentoHorarios_Grupo3Db
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EspecialidadesEnfermeiros",
                columns: table => new
                {
                    EspecialidadeEnfermeiroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Especialidade = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadesEnfermeiros", x => x.EspecialidadeEnfermeiroId);
                });

            migrationBuilder.CreateTable(
                name: "Enfermeiros",
                columns: table => new
                {
                    EnfermeiroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroMecanografico = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    EspecialidadeEnfermeiroId = table.Column<int>(nullable: false),
                    Contacto = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Data_Nascimento = table.Column<DateTime>(nullable: false),
                    CC = table.Column<string>(nullable: false),
                    Filhos = table.Column<bool>(nullable: false),
                    Data_Nascimento_Filho = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiros", x => x.EnfermeiroId);
                    table.ForeignKey(
                        name: "FK_Enfermeiros_EspecialidadesEnfermeiros_EspecialidadeEnfermeiroId",
                        column: x => x.EspecialidadeEnfermeiroId,
                        principalTable: "EspecialidadesEnfermeiros",
                        principalColumn: "EspecialidadeEnfermeiroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnfermeirosEspecialidades",
                columns: table => new
                {
                    EspecialidadeEnfermeiroId = table.Column<int>(nullable: false),
                    EnfermeiroId = table.Column<int>(nullable: false),
                    Data_Registo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfermeirosEspecialidades", x => new { x.EnfermeiroId, x.EspecialidadeEnfermeiroId });
                    table.ForeignKey(
                        name: "FK_EnfermeirosEspecialidades_Enfermeiros_EnfermeiroId",
                        column: x => x.EnfermeiroId,
                        principalTable: "Enfermeiros",
                        principalColumn: "EnfermeiroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnfermeirosEspecialidades_EspecialidadesEnfermeiros_EspecialidadeEnfermeiroId",
                        column: x => x.EspecialidadeEnfermeiroId,
                        principalTable: "EspecialidadesEnfermeiros",
                        principalColumn: "EspecialidadeEnfermeiroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfermeiros_EspecialidadeEnfermeiroId",
                table: "Enfermeiros",
                column: "EspecialidadeEnfermeiroId");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermeirosEspecialidades_EspecialidadeEnfermeiroId",
                table: "EnfermeirosEspecialidades",
                column: "EspecialidadeEnfermeiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnfermeirosEspecialidades");

            migrationBuilder.DropTable(
                name: "Enfermeiros");

            migrationBuilder.DropTable(
                name: "EspecialidadesEnfermeiros");
        }
    }
}
