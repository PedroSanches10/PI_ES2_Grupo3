using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EscalonamentoHorarios_Grupo3.Models;

namespace EscalonamentoHorarios_Grupo3.Models
{
    public class EscalonamentoHorarios_Grupo3DbContext : DbContext
    {
        public EscalonamentoHorarios_Grupo3DbContext (DbContextOptions<EscalonamentoHorarios_Grupo3DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Chave primária composta
            modelBuilder.Entity<EnfermeiroEspecialidade>().HasKey(o => new { o.EnfermeiroId, o.EspecialidadeEnfermeiroId });

            //Relação 1 -> N
            modelBuilder.Entity<EnfermeiroEspecialidade>()
                .HasOne(ee => ee.Enfermeiro)
                .WithMany(e => e.EnfermeirosEspecialidade)
                .HasForeignKey(ee => ee.EnfermeiroId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EnfermeiroEspecialidade>()
                .HasOne(ee => ee.EspecialidadeEnfermeiro)
                .WithMany(e => e.EnfermeirosEspecialidade)
                .HasForeignKey(ee => ee.EspecialidadeEnfermeiroId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<EscalonamentoHorarios_Grupo3.Models.Enfermeiro> Enfermeiros { get; set; }

        public DbSet<EscalonamentoHorarios_Grupo3.Models.EnfermeiroEspecialidade> EnfermeirosEspecialidades { get; set; }

        public DbSet<EscalonamentoHorarios_Grupo3.Models.EspecialidadeEnfermeiro> EspecialidadesEnfermeiros { get; set; }

        public DbSet<EscalonamentoHorarios_Grupo3.Models.HorarioEnfermeiro> HorariosEnfermeiro { get; set; }

        public DbSet<EscalonamentoHorarios_Grupo3.Models.Turno> Turnos { get; set; }
    }
}

