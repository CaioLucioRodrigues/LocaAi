using System;
using System.ComponentModel.DataAnnotations;

namespace LocaAi.Domain.Entities
{
    public abstract class LocaAiEntityBase
    {           
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
