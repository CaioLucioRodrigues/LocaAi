using LocaAi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocaAi.Presentation.Site.ViewModels
{
    public class CaracteristicaViewModel
    {
        [Key]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(200, ErrorMessage = "O tamanho máximo do campo é de 200 caracteres")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Ativo ?")]
        public bool Ativo { get; set; }

        //public List<CaracteristicaOpcao> Opcoes { get; set; }
    }
}
