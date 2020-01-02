using LocaAi.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace LocaAi.Presentation.Site.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(200, ErrorMessage = "O tamanho máximo do campo é de 200 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [StringLength(200, ErrorMessage = "O tamanho máximo do campo é de 2000 caracteres")]
        public string Descricao { get; set; }

        public Categoria Categoria { get; set; }

        public Usuario Usuario { get; set; }
    }
}
