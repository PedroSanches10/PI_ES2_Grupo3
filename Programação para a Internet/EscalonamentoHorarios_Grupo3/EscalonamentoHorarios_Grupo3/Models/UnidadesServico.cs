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

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime Horario { get; set; }

        [Required]
        public DateTime AnosServico { get; set; }

        [Required]
        public string Turnos { get; set; }

        [Required]
        public string Enfermeiro { get; set; }

       

        

    }
}
