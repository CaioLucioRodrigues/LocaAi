using System;
using System.Collections.Generic;
using System.Text;

namespace LocaAi.Domain.Entities
{
    public class LocaAiEntityBase
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
