using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EscalonamentoHorarios_Grupo3.Models
{
    

    public class Enfermeiro
    {
        
        public int EnfermeiroID { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Introduza o nome")]
        public string Nome { get; set; }

       

       

        public string Morada { get; set; }

        [Required]
        public string UnidadeServico { get; set; }

        [RegularExpression(@"\d\d\d\d(-\d\d\d)?", ErrorMessage = "Código postal inválido")]
        [Display(Name = "Código postal")]
        public string CodPostal { get; set; }

        [Required(ErrorMessage = "Introduza o email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Telemóvel inválido")]
        [Display(Name = "Telemóvel")]
        public string Telemovel { get; set; }

        [Required(ErrorMessage = "Introduza a data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "Introduza o Nif")]
        [Display(Name = "Contribuinte")]
        public string NIF { get; set; }

    }

    
}
