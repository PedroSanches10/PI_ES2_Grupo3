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

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Chave primária composta
            modelBuilder.Entity<UnidadesServico>().HasKey(o => new { o.EnfermeiroID, o.UnidadesServicoID
    });

            //Relação 1 -> N
            modelBuilder.Entity<Enfermeiro>()
                .HasOne(ee => ee.UnidadesServicos)
                .WithMany(e => e.E)
                .HasForeignKey(ee => ee.EnfermeiroID)
                .OnDelete(DeleteBehavior.Cascade);

    

            base.OnModelCreating(modelBuilder);
}*/

public DbSet<EscalonamentoHorarios_Grupo3.Models.Enfermeiro> Enfermeiros { get; set; }

        public DbSet<EscalonamentoHorarios_Grupo3.Models.UnidadesServico> UnidadesServicos { get; set; }
    }
}

