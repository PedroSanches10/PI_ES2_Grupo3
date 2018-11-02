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

        public DbSet<EscalonamentoHorarios_Grupo3.Models.Enfermeiro> Enfermeiro { get; set; }

        public DbSet<EscalonamentoHorarios_Grupo3.Models.UnidadesServico> UnidadesServico { get; set; }
    }
}
