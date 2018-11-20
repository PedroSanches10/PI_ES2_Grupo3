﻿// <auto-generated />
using System;
using EscalonamentoHorarios_Grupo3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EscalonamentoHorarios_Grupo3.Migrations
{
    [DbContext(typeof(EscalonamentoHorarios_Grupo3DbContext))]
    partial class EscalonamentoHorarios_Grupo3DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EscalonamentoHorarios_Grupo3.Models.Enfermeiro", b =>
                {
                    b.Property<int>("EnfermeiroID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodPostal");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Morada");

                    b.Property<string>("NIF")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Telemovel");

                    b.Property<string>("UnidadeServico")
                        .IsRequired();

                    b.HasKey("EnfermeiroID");

                    b.ToTable("Enfermeiros");
                });

            modelBuilder.Entity("EscalonamentoHorarios_Grupo3.Models.UnidadesServico", b =>
                {
                    b.Property<int>("UnidadesServicoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AnosServico");

                    b.Property<string>("Enfermeiro")
                        .IsRequired();

                    b.Property<DateTime>("Horario");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Turnos")
                        .IsRequired();

                    b.HasKey("UnidadesServicoID");

                    b.ToTable("UnidadesServicos");
                });
#pragma warning restore 612, 618
        }
    }
}
