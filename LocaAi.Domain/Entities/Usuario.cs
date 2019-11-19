using System;

namespace LocaAi.Domain.Entities
{
    public class Usuario: LocaAiEntityBase
    {   
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public double Pontuacao { get; set; }
    }
}
