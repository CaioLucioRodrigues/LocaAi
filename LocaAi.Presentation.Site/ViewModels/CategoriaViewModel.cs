﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocaAi.Presentation.Site.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(200, ErrorMessage = "O tamanho máximo do campo é de 200 caracteres")]
        public string Nome { get; set; }

        [StringLength(2000, ErrorMessage = "O tamanho máximo do campo é de 2000 caracteres")]
        public string Descricao { get; set; }

        [Required]
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }
    }
}
