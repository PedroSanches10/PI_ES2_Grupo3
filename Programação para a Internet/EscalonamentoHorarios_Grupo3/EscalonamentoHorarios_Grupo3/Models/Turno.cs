using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscalonamentoHorarios_Grupo3.Models
{
    public class Turno
    {
        public int TurnoId { get; set; }
        public string Nome { get; set; }

        public ICollection<HorarioEnfermeiro> HorariosEnfermeiro { get; set; }
    }
}
