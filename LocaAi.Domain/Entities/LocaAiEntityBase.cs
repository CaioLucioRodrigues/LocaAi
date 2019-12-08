using System;
using System.ComponentModel.DataAnnotations;

namespace LocaAi.Domain.Entities
{
    public class LocaAiEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
