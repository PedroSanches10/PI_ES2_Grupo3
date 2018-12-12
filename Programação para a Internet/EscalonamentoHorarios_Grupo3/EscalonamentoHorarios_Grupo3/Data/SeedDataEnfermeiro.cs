using EscalonamentoHorarios_Grupo3.Controllers;
using EscalonamentoHorarios_Grupo3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscalonamentoHorarios_Grupo3.Data
{
    public static class SeedData

    {
        private const string ROLE_ADMINISTRATOR = "Administrator";
        private const string ROLE_CUSTOMER = "Customer";

        public static void Enfermeiro(EscalonamentoHorarios_Grupo3DbContext db)
        {
            SeedEnfermeiro(db);
            SeedServico(db);

        }

        

        private static async void MakeSureRoleExistsAsync(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        public static async Task CreateRolesAndUsersAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string ADMIN_USER = "admin@noemail.com";
            const string ADMIN_PASSWORD = "sECRET$123";

            MakeSureRoleExistsAsync(roleManager, ROLE_ADMINISTRATOR);
            MakeSureRoleExistsAsync(roleManager, ROLE_CUSTOMER);

            IdentityUser admin = await userManager.FindByNameAsync(ADMIN_USER);
            if (admin == null)
            {
                admin = new IdentityUser { UserName = ADMIN_USER };
                await userManager.CreateAsync(admin, ADMIN_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(admin, ROLE_ADMINISTRATOR))
            {
                await userManager.AddToRoleAsync(admin, ROLE_ADMINISTRATOR);
            }
        }
        public static async Task CreateTestUsersAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string CUSTOMER_USER = "john@noemail.com";
            const string CUSTOMER_PASSWORD = "sECREDO$123";

            IdentityUser customer = await userManager.FindByNameAsync(CUSTOMER_USER);
            if (customer == null)
            {
                customer = new IdentityUser { UserName = CUSTOMER_USER };
                await userManager.CreateAsync(customer, CUSTOMER_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(customer, ROLE_CUSTOMER))
            {
                await userManager.AddToRoleAsync(customer, ROLE_CUSTOMER);
            }
        }

        
        private static void SeedServico(EscalonamentoHorarios_Grupo3DbContext db)
        {
            if (db.UnidadesServicos.Any()) return;

            db.UnidadesServicos.AddRange(

                new UnidadesServico { Servico = "Teste" },
                new UnidadesServico { Servico = "Enfermagem Médico-Cirúrgica", }
                

                );
            if (db.UnidadesServicos.Any()) return;

            UnidadesServico servico = GetUnidadeServicoCreatingIfNeed(db, "Enfermagem Geral");
            Enfermeiro enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "Marisa Reduto");
            db.UnidadesServicos.Add(new UnidadesServico { EnfermeiroID = servico.UnidadesServicoID, UnidadesServicoID = servico.EnfermeiroID, Data = new DateTime(2018, 11, 16) });

            db.UnidadesServicos.AddRange(
                    new UnidadesServico { UnidadesServicoID = 1, EnfermeiroID = 1, Data  = new DateTime (1), Servico = "Pneumologia" },
                    new UnidadesServico { UnidadesServicoID = 2, EnfermeiroID = 2, Data = new DateTime(2), Servico = "Enfermagem geral" },
                    new UnidadesServico { UnidadesServicoID = 3, EnfermeiroID = 3, Data = new DateTime(3), Servico = "Pneumologia" },
                    new UnidadesServico { UnidadesServicoID = 4, EnfermeiroID = 4, Data = new DateTime(4), Servico = "Pneumologia" }
                    );
            db.SaveChanges();
        }

        private static void SeedEnfermeiro(EscalonamentoHorarios_Grupo3DbContext db)
        {
            if (db.Enfermeiros.Any()) return;

            UnidadesServico geral = GetUnidadeServicoCreatingIfNeed(db, "Enfermagem Geral");

            db.Enfermeiros.AddRange(
                    new Enfermeiro { NumeroEnf = "E001", Nome = "Micael Santos", UnidadesServicos = geral.UnidadesServicos , Telemovel = "961234567", Email = "maria@gmail.com", DataNascimento = new DateTime(1992, 05, 12), NIF = "200123456", Filhos = false, DataNascimentoFilhos = null },
                    new Enfermeiro { NumeroEnf = "E001", Nome = "Micael Santos", UnidadesServicos = geral.UnidadesServicos , Telemovel = "961234567", Email = "maria@gmail.com", DataNascimento = new DateTime(1992, 05, 12), NIF = "200123456", Filhos = true, DataNascimentoFilhos = new DateTime(2016, 7, 10) },
                    new Enfermeiro { NumeroEnf = "E001", Nome = "Micael Santos", UnidadesServicos = geral.UnidadesServicos, Telemovel = "961234567", Email = "maria@gmail.com", DataNascimento = new DateTime(1992, 05, 12), NIF = "200123456", Filhos = true, DataNascimentoFilhos = new DateTime(2016, 7, 10) },
                    new Enfermeiro { NumeroEnf = "E001", Nome = "Micael Santos", UnidadesServicos = geral.UnidadesServicos, Telemovel = "961234567", Email = "maria@gmail.com", DataNascimento = new DateTime(1992, 05, 12), NIF = "200123456", Filhos = true, DataNascimentoFilhos = new DateTime(2016, 7, 10) },
                    new Enfermeiro { NumeroEnf = "E001", Nome = "Micael Santos", UnidadesServicos = geral.UnidadesServicos, Telemovel = "961234567", Email = "maria@gmail.com", DataNascimento = new DateTime(1992, 05, 12), NIF = "200123456", Filhos = false, DataNascimentoFilhos = null },
                    new Enfermeiro { NumeroEnf = "E001", Nome = "Micael Santos", UnidadesServicos = geral.UnidadesServicos, Telemovel = "961234567", Email = "maria@gmail.com", DataNascimento = new DateTime(1992, 05, 12), NIF = "200123456", Filhos = true, DataNascimentoFilhos = new DateTime(2016, 7, 10) },
                    new Enfermeiro { NumeroEnf = "E001", Nome = "Micael Santos", UnidadesServicos = geral.UnidadesServicos, Telemovel = "961234567", Email = "maria@gmail.com", DataNascimento = new DateTime(1992, 05, 12), NIF = "200123456", Filhos = true, DataNascimentoFilhos = new DateTime(2016, 7, 10) },
                    new Enfermeiro { NumeroEnf = "E001", Nome = "Micael Santos", UnidadesServicos = geral.UnidadesServicos, Telemovel = "961234567", Email = "maria@gmail.com", DataNascimento = new DateTime(1992, 05, 12), NIF = "200123456", Filhos = true, DataNascimentoFilhos = new DateTime(2016, 7, 10) },
                    new Enfermeiro { NumeroEnf = "E001", Nome = "Micael Santos", UnidadesServicos = geral.UnidadesServicos, Telemovel = "961234567", Email = "maria@gmail.com", DataNascimento = new DateTime(1992, 05, 12), NIF = "200123456", Filhos = false, DataNascimentoFilhos = null },
                    new Enfermeiro { NumeroEnf = "E001", Nome = "Micael Santos", UnidadesServicos = geral.UnidadesServicos, Telemovel = "961234567", Email = "maria@gmail.com", DataNascimento = new DateTime(1992, 05, 12), NIF = "200123456", Filhos = true, DataNascimentoFilhos = new DateTime(2016, 7, 10), }
                    );
            db.SaveChanges();
        }
            private static UnidadesServico GetUnidadeServicoCreatingIfNeed(EscalonamentoHorarios_Grupo3DbContext db, string name)
            {
                UnidadesServico servico = db.UnidadesServicos.SingleOrDefault(c => c.Servico == name);

                if (servico == null)
                {
                    servico = new UnidadesServico { Servico = name };
                    db.Add(servico);
                    db.SaveChanges();
                }

                return servico;
            }
        }
    }
    
    

