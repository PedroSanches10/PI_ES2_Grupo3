using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscalonamentoHorarios_Grupo3.Models
{
    public class Voluntario
    {
        public int VoluntarioID { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Introduza o nome")]

        public string Nome { get; set; }
        [Required]

        public string Password { get; set; }
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]

        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Confirma password")]
        [Compare("Password", ErrorMessage = "A password e a sua confirmação não são iguais.")]

        public string Morada { get; set; }


        public string CodPostal { get; set; }
        [RegularExpression(@"\d\d\d\d(-\d\d\d)?", ErrorMessage = "Código postal inválido")]
        [Display(Name = "Código postal")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Introduza o email")]
        [EmailAddress(ErrorMessage = "Email inválido")]

        public string Telemovel { get; set; }
        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Telemóvel inválido")]
        [Display(Name = "Telemóvel")]


        public string DataNascimento { get; set; }
        [Required(ErrorMessage = "Introduza a data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]

        public string NIF { get; set; }
        [Required(ErrorMessage = "Introduza o Nif")]
        [Display(Name = "Contribuinte")]

    }
}

