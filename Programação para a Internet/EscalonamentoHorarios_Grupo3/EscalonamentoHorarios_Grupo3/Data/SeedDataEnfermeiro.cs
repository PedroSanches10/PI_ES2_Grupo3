﻿using EscalonamentoHorarios_Grupo3.Models;
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
            SeedEnfermeiros(db);
            SeedEspecialidadeEnfermeiros(db);
            SeedEnfermeiroEspecialidade(db);

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


        private static void SeedEspecialidadeEnfermeiros(EscalonamentoHorarios_Grupo3DbContext db)
        {
            if (db.EspecialidadesEnfermeiros.Any()) return;

            db.EspecialidadesEnfermeiros.AddRange(

                new EspecialidadeEnfermeiro { Especialidade = "Enfermagem Comunitária" },
                new EspecialidadeEnfermeiro { Especialidade = "Enfermagem Médico-Cirúrgica" },
                new EspecialidadeEnfermeiro { Especialidade = "Enfermagem de Reabilitação" },
                new EspecialidadeEnfermeiro { Especialidade = "Enfermagem de Saúde Infantil e Pediátrica" },
                new EspecialidadeEnfermeiro { Especialidade = "Enfermagem de Saúde Materna e Obstétrica" },
                new EspecialidadeEnfermeiro { Especialidade = "Enfermagem de Saúde Mental e Psiquiátrica" }

                );

            db.SaveChanges();
        }

        private static void SeedEnfermeiroEspecialidade(EscalonamentoHorarios_Grupo3DbContext db)
        {
            if (db.EnfermeirosEspecialidades.Any()) return;

            EspecialidadeEnfermeiro especialidade = GetEspecialidadeCreatingIfNeed(db, "Enfermagem Comunitária");
            Enfermeiro enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "Marisa Reduto");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            especialidade = GetEspecialidadeCreatingIfNeed(db, "Enfermagem Médico-Cirúrgica");
            enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "João Silva");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            especialidade = GetEspecialidadeCreatingIfNeed(db, "Enfermagem de Reabilitação");
            enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "Armando Manso");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "Andreia Cunha");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "Joana Albuquerque");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "João Tomás");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "Carlos Manso");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "Bruno Martins");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "Ariana Gonçalves");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "André Silva");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "Carlos Almeida");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            enfermeiro = db.Enfermeiros.SingleOrDefault(e => e.Nome == "Fábio Castro");
            db.EnfermeirosEspecialidades.Add(new EnfermeiroEspecialidade { EspecialidadeEnfermeiroId = especialidade.EspecialidadeEnfermeiroId, EnfermeiroId = enfermeiro.EnfermeiroId, Data_Registo = new DateTime(2018, 11, 16) });

            db.SaveChanges();
        }

        private static void SeedEnfermeiros(EscalonamentoHorarios_Grupo3DbContext db)
        {
            if (db.Enfermeiros.Any()) return;

            EspecialidadeEnfermeiro comunitaria = GetEspecialidadeCreatingIfNeed(db, "Enfermagem Comunitária");
            EspecialidadeEnfermeiro reabilitacao = GetEspecialidadeCreatingIfNeed(db, "Enfermagem de Reabilitação");
            EspecialidadeEnfermeiro saudeInfantil = GetEspecialidadeCreatingIfNeed(db, "Enfermagem de Saúde Infantil e Pediátrica");
            EspecialidadeEnfermeiro saudeMaterna = GetEspecialidadeCreatingIfNeed(db, "Enfermagem de Saúde Materna e Obstétrica");
            EspecialidadeEnfermeiro saudeMental = GetEspecialidadeCreatingIfNeed(db, "Enfermagem de Saúde Mental e Psiquiátrica");
            EspecialidadeEnfermeiro medicoCirurgica = GetEspecialidadeCreatingIfNeed(db, "Enfermagem Médico-Cirúrgica");

            db.Enfermeiros.AddRange(

                new Enfermeiro { NumeroMecanografico = "E001", Nome = "Marisa Reduto", EspecialidadeEnfermeiroId = comunitaria.EspecialidadeEnfermeiroId, Contacto = "966333222", Email = "marisareduto@uls.guarda", Data_Nascimento = new DateTime(1998, 6, 6), CC = "15823256", Filhos = false, Data_Nascimento_Filho = null },
                new Enfermeiro { NumeroMecanografico = "E002", Nome = "João Silva", EspecialidadeEnfermeiroId = medicoCirurgica.EspecialidadeEnfermeiroId, Contacto = "965241232", Email = "joaosilva@uls.guarda", Data_Nascimento = new DateTime(1989, 8, 16), CC = "15852556", Filhos = true, Data_Nascimento_Filho = new DateTime(2016, 7, 10) },
                new Enfermeiro { NumeroMecanografico = "E003", Nome = "Armando Manso", EspecialidadeEnfermeiroId = reabilitacao.EspecialidadeEnfermeiroId, Contacto = "964521121", Email = "armandomanso@uls.guarda", Data_Nascimento = new DateTime(1987, 7, 1), CC = "13652544", Filhos = true, Data_Nascimento_Filho = new DateTime(2018, 8, 23) },
                new Enfermeiro { NumeroMecanografico = "E004", Nome = "Andreia Cunha", EspecialidadeEnfermeiroId = reabilitacao.EspecialidadeEnfermeiroId, Contacto = "923654152", Email = "andreiacunha@uls.guarda", Data_Nascimento = new DateTime(1978, 10, 25), CC = "14245485", Filhos = false, Data_Nascimento_Filho = null },
                new Enfermeiro { NumeroMecanografico = "E342", Nome = "Joana Albuquerque", EspecialidadeEnfermeiroId = comunitaria.EspecialidadeEnfermeiroId, Contacto = "968951742", Email = "joanaalbuquerque@uls.guarda", Data_Nascimento = new DateTime(1998, 6, 6), CC = "15823256", Filhos = false, Data_Nascimento_Filho = null },
                new Enfermeiro { NumeroMecanografico = "E392", Nome = "João Tomás", EspecialidadeEnfermeiroId = medicoCirurgica.EspecialidadeEnfermeiroId, Contacto = "965254874", Email = "joaotomas@uls.guarda", Data_Nascimento = new DateTime(1989, 8, 16), CC = "15852556", Filhos = false, Data_Nascimento_Filho = null },
                new Enfermeiro { NumeroMecanografico = "E783", Nome = "Carlos Manso", EspecialidadeEnfermeiroId = reabilitacao.EspecialidadeEnfermeiroId, Contacto = "964521741", Email = "carlosmanso@uls.guarda", Data_Nascimento = new DateTime(1987, 7, 1), CC = "13652544", Filhos = false, Data_Nascimento_Filho = null },
                new Enfermeiro { NumeroMecanografico = "E124", Nome = "Bruno Martins", EspecialidadeEnfermeiroId = reabilitacao.EspecialidadeEnfermeiroId, Contacto = "923254152", Email = "brunomartins@uls.guarda", Data_Nascimento = new DateTime(1978, 10, 25), CC = "14245485", Filhos = false, Data_Nascimento_Filho = null },
                new Enfermeiro { NumeroMecanografico = "E451", Nome = "Ariana Gonçalves", EspecialidadeEnfermeiroId = comunitaria.EspecialidadeEnfermeiroId, Contacto = "969876222", Email = "arianagoncalves@uls.guarda", Data_Nascimento = new DateTime(1998, 6, 6), CC = "15823256", Filhos = false, Data_Nascimento_Filho = null },
                new Enfermeiro { NumeroMecanografico = "E762", Nome = "André Silva", EspecialidadeEnfermeiroId = medicoCirurgica.EspecialidadeEnfermeiroId, Contacto = "968745232", Email = "andresilva@uls.guarda", Data_Nascimento = new DateTime(1989, 8, 16), CC = "15852556", Filhos = false, Data_Nascimento_Filho = null },
                new Enfermeiro { NumeroMecanografico = "E983", Nome = "Carlos Almeida", EspecialidadeEnfermeiroId = reabilitacao.EspecialidadeEnfermeiroId, Contacto = "967845621", Email = "carlosalmeida@uls.guarda", Data_Nascimento = new DateTime(1987, 7, 1), CC = "13652544", Filhos = true, Data_Nascimento_Filho = new DateTime(2018, 8, 23) },
                new Enfermeiro { NumeroMecanografico = "E125", Nome = "Fábio Castro", EspecialidadeEnfermeiroId = reabilitacao.EspecialidadeEnfermeiroId, Contacto = "923256452", Email = "fabiocastro@uls.guarda", Data_Nascimento = new DateTime(1978, 10, 25), CC = "14245485", Filhos = true, Data_Nascimento_Filho = new DateTime(2018, 8, 23) }

                );

            db.SaveChanges();
        }
        private static EspecialidadeEnfermeiro GetEspecialidadeCreatingIfNeed(EscalonamentoHorarios_Grupo3DbContext db, string name)
        {
            EspecialidadeEnfermeiro especialidade = db.EspecialidadesEnfermeiros.SingleOrDefault(c => c.Especialidade == name);

            if (especialidade == null)
            {
                especialidade = new EspecialidadeEnfermeiro { Especialidade = name };
                db.Add(especialidade);
                db.SaveChanges();
            }

            return especialidade;
        }
    }
    }
    
    

