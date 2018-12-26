using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EscalonamentoHorarios_Grupo3.Models
{
    public class EnfermeirosListViewModel
    {
        public IEnumerable<Enfermeiro> Enfermeiros { get; set; }
        public PagingViewModel Paginacao { get; set; }

        [DisplayName("Nome")]
        public string CurrentNome{ get; set; }

        public IEnumerable<EnfermeiroEspecialidade> EnfermeirosEspecialidades { get; set; }
        public PagingViewModel Pagination { get; set; }

        public string CurrentName { get; set; }
    }
}
