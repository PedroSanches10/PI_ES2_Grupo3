using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscalonamentoHorarios_Grupo3.Models
{
    public class EnfermeiroEspecialidade
    {

        public int EspecialidadeEnfermeiroId { get; set; }
        public EspecialidadeEnfermeiro EspecialidadeEnfermeiro { get; set; }

        public Enfermeiro Enfermeiro { get; set; }
        public int EnfermeiroId { get; set; }

        public DateTime Data_Registo { get; set; }
       
    }
}
