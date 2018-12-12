using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscalonamentoHorarios_Grupo3.Models

{
    public class UnidadesServico
    {

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Introduza o nome")]
        public int UnidadesServicoID { get; set; }

        [Required(ErrorMessage = "Introduza o nome para a unidade de serviço")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Nome inválido")]
        public string Servico { get; set; }

        public int EnfermeiroID { get; set; }

        public DateTime Data { get; set; }



        public Enfermeiro Enfermeiro
        { get; set; }


        public ICollection<Enfermeiro> Enfermeiros { get; set; }
        public ICollection<UnidadesServico> UnidadesServicos { get; set; }


        }
    }
