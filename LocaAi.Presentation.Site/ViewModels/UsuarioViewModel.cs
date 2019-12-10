using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAi.Presentation.Site.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(200, ErrorMessage = "O tamanho máximo do campo é de 200 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "A senha precisa ter entre 6 e 15 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Email em formato incorreto")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Avaliação é obrigatório")]
        [Range(0, 10, ErrorMessage = "Pontuação deve ser entre 0 e 10")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Somente números")]
        [DisplayName("Avaliação")]
        public double Pontuacao { get; set; }
    }
}
