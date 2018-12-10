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
        public string CurrentName{ get; set; }
    }
}
