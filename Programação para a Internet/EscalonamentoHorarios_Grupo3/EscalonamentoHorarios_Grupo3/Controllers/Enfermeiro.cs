using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EscalonamentoHorarios_Grupo3.Models;

/*
namespace EscalonamentoHorarios_Grupo3.Controllers

{
    public class Enfermeiro: Controller
    {
        private DateTime[] Horario(){

            string message;

            // Cria lista de retorno
            var regressar = new List<DateTime>();

                // Define o primeiro horario
                var horario = new DateTime(ano, mes, dia, 0, 0, 0);

                // Para cada hora do dia
                for (int i = 0; i < 23; i++)
                {
                    // Adiciona o horario para lista de retorno
                    regressar.Add(horario);

                    // Soma 30 minutos no horario atual
                    horario.AddMinutes(30);

                    // Adiciona horario com mais meia hora para a lista de retorno
                    regressar.Add(horario);

                    // Soma mais 30 minutos para chegar no proximo horario redondo
                    horario.AddMinutes(30);
                }

                // Retorna lista de horarios
                return regressar.ToArray();

                Horario = horario.AddMinutes(30);

            ViewBag.Message = message;
        }



        }
       
    }



    */