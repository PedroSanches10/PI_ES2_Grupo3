using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EscalonamentoHorarios_Grupo3.Models
{
    public static class SeedDataEnfermeiro

    {
            
                public static void Initialize(IServiceProvider serviceProvider)
                {
                    using (var context = new EscalonamentoHorarios_Grupo3DbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<EscalonamentoHorarios_Grupo3DbContext>>()))
                    {
                    // Look for any movies.
                    if (context.Enfermeiro.Any())
                        {
                            return;   // DB has been seeded
                    }

                        context.Enfermeiro.AddRange(
                    new Enfermeiro { Nome = "Maria Santos", Telemovel = "961234567", UnidadeServico = "Enfermagem geral", Email = "maria@gmail.com", CodPostal = "6300-786", NIF = "200123456", Morada = "Guarda" },
                new Enfermeiro { Nome = "Manuel Silva", Telemovel = "962345678", UnidadeServico = "Enfermagem médico-cirúrgica", Email = "manuel@gmail.com", CodPostal = "423", NIF = "200123421", Morada = "Guarda" },
                new Enfermeiro { Nome = "João Tavares", Telemovel = "963456789", UnidadeServico = "Enfermagem obstétrica", Email = "joao@gmail.com", CodPostal = "6300-342", NIF = "200123321", Morada = "Guarda" },
                new Enfermeiro { Nome = "Luís Cunha", Telemovel = "965678901", UnidadeServico = "Enfermagem pediátrica", Email = "luis@gmail.com", CodPostal = "6300-897", NIF = "200765321", Morada = "Guarda" },
                new Enfermeiro { Nome = "António Costa", Telemovel = "966789012", UnidadeServico = "Enfermagem psiquiátrica", Email = "antonio@gmail.com", CodPostal = "6300-432", NIF = "20012980", Morada = "Guarda" },
                new Enfermeiro { Nome = "Sílvia Correia", Telemovel = "967890123", UnidadeServico = "Enfermagem geral", Email = "silvia@gmail.com", CodPostal = "6300-210", NIF = "200121432", Morada = "Guarda" },
                new Enfermeiro { Nome = "Joana Pereira", Telemovel = "968901234", UnidadeServico = "Enfermagem médico-cirúrgica", Email = "joana@gmail.com", CodPostal = "6300-521", NIF = "200123000", Morada = "Guarda" },
                new Enfermeiro { Nome = "Ricardo Ramos", Telemovel = "969012345", UnidadeServico = "Enfermagem obstétrica", Email = "ricrdo@gmail.com", CodPostal = "6300-512", NIF = "200123001", Morada = "Guarda" },
                new Enfermeiro { Nome = "Nelson Duarte", Telemovel = "912345678", UnidadeServico = "Enfermagem Pediátrica", Email = "nelson@gmail.com", CodPostal = "6300-530", NIF = "200123123", Morada = "Guarda" },
                new Enfermeiro { Nome = "Luísa Rocha", Telemovel = "913456789", UnidadeServico = "Enfermagem psiquiátrica", Email = "luisa@gmail.com", CodPostal = "6300-538", NIF = "200123999", Morada = "Guarda",  }
                );
                context.SaveChanges();
            }
        }

        
    }
}