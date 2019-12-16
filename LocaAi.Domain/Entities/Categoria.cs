using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocaAi.Domain.Entities
{
    public class Categoria : LocaAiEntityBase
    {   
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
