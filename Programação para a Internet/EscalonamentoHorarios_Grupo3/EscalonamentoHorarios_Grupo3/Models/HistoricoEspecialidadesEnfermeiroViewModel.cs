using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscalonamentoHorarios_Grupo3.Models
{
    public class HistoricoEspecialidadesEnfermeiroViewModel
    {
        public IEnumerable<EnfermeiroEspecialidade> EnfermeirosEspecialidades { get; set; }
        public PagingViewModel Pagination { get; set; }

        public string CurrentNome { get; set; }
    }
}
