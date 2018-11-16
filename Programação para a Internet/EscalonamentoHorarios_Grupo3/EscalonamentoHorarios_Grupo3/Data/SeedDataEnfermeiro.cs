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
        /*private const string ROLE_ADMINISTRATOR = "Administrator";
        private const string ROLE_CUSTOMER = "Customer";*/

        public static void Enfermeiro(EscalonamentoHorarios_Grupo3DbContext db)
        {
            SeedEnfermeiro(db);
            SeedServico(db);

        }

        

        /*private static async void MakeSureRoleExistsAsync(RoleManager<IdentityRole> roleManager, string role)
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
        }*/
        private static void SeedServico(EscalonamentoHorarios_Grupo3DbContext db)
        {
            if (db.UnidadesServicos.Any()) return;

            db.UnidadesServicos.AddRange(
                    new UnidadesServico { Nome = "Maria Santos", UnidadesServicoID = 1, Enfermeiro = "maria@gmail.com", Turnos = "200123456", },
                    new UnidadesServico { Nome = "Manuel Silva", UnidadesServicoID = 2, Enfermeiro = "manuel@gmail.com", Turnos = "200123421" },
                    new UnidadesServico { Nome = "João Tavares", UnidadesServicoID = 3, Enfermeiro = "joao@gmail.com", Turnos = "200123321" },
                    new UnidadesServico { Nome = "Luís Cunha", UnidadesServicoID = 4, Enfermeiro = "luis@gmail.com", Turnos = "200765321" }
                    );
            db.SaveChanges();
        }

        private static void SeedEnfermeiro(EscalonamentoHorarios_Grupo3DbContext db)
        {
            if (db.Enfermeiros.Any()) return;

            db.Enfermeiros.AddRange(
                    new Enfermeiro{ Nome = "Maria Santos", Telemovel = "961234567", UnidadeServico = "Enfermagem geral", Email = "maria@gmail.com", CodPostal = "6300-786", NIF = "200123456", Morada = "Guarda" },
                    new Enfermeiro { Nome = "Manuel Silva", Telemovel = "962345678", UnidadeServico = "Enfermagem médico-cirúrgica", Email = "manuel@gmail.com", CodPostal = "423", NIF = "200123421", Morada = "Guarda" },
                    new Enfermeiro { Nome = "João Tavares", Telemovel = "963456789", UnidadeServico = "Enfermagem obstétrica", Email = "joao@gmail.com", CodPostal = "6300-342", NIF = "200123321", Morada = "Guarda" },
                    new Enfermeiro { Nome = "Luís Cunha", Telemovel = "965678901", UnidadeServico = "Enfermagem pediátrica", Email = "luis@gmail.com", CodPostal = "6300-897", NIF = "200765321", Morada = "Guarda" },
                    new Enfermeiro { Nome = "António Costa", Telemovel = "966789012", UnidadeServico = "Enfermagem psiquiátrica", Email = "antonio@gmail.com", CodPostal = "6300-432", NIF = "20012980", Morada = "Guarda" },
                    new Enfermeiro { Nome = "Sílvia Correia", Telemovel = "967890123", UnidadeServico = "Enfermagem geral", Email = "silvia@gmail.com", CodPostal = "6300-210", NIF = "200121432", Morada = "Guarda" },
                    new Enfermeiro { Nome = "Joana Pereira", Telemovel = "968901234", UnidadeServico = "Enfermagem médico-cirúrgica", Email = "joana@gmail.com", CodPostal = "6300-521", NIF = "200123000", Morada = "Guarda" },
                    new Enfermeiro { Nome = "Ricardo Ramos", Telemovel = "969012345", UnidadeServico = "Enfermagem obstétrica", Email = "ricrdo@gmail.com", CodPostal = "6300-512", NIF = "200123001", Morada = "Guarda" },
                    new Enfermeiro { Nome = "Nelson Duarte", Telemovel = "912345678", UnidadeServico = "Enfermagem Pediátrica", Email = "nelson@gmail.com", CodPostal = "6300-530", NIF = "200123123", Morada = "Guarda" },
                    new Enfermeiro { Nome = "Luísa Rocha", Telemovel = "913456789", UnidadeServico = "Enfermagem psiquiátrica", Email = "luisa@gmail.com", CodPostal = "6300-538", NIF = "200123999", Morada = "Guarda", }
                    );
            db.SaveChanges();
        }
    }
    
    
}
