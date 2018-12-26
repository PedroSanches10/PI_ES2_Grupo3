﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EscalonamentoHorarios_Grupo3.Models
{
    public class Enfermeiro
    {
        public int EnfermeiroId { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o seu número mecanográfico")]
        [RegularExpression(@"[E]\d+", ErrorMessage = "Número errado")]
        public string NumeroMecanografico { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o nome")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Nome inválido")]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Nome { get; set; }

        public EspecialidadeEnfermeiro EspecialidadeEnfermeiro { get; set; }
        public int EspecialidadeEnfermeiroId { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o seu número de telemóvel/telefone")]
        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Contacto inválido")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a data de nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Data_Nascimento { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o nº de CC/BI")]
        //[RegularExpression(@"\d{8}(\s\d{1})?", ErrorMessage = "Nº de CC/BI inválido")]
        [RegularExpression(@"(\d{8}\s\d{1}[A-Z0-9]{2}\d{1})", ErrorMessage = "Nº de CC/BI inválido")]
        public string CC { get; set; }

        [Required]
        public bool? Filhos { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? Data_Nascimento_Filho { get; set; }


        public ICollection<EnfermeiroEspecialidade> EnfermeirosEspecialidade { get; set; }
        //public ICollection<HorarioEnfermeiro> HorariosEnfermeiro { get; set; }


    }
}
