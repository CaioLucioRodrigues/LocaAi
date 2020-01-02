using System.Collections.Generic;

namespace LocaAi.Domain.Entities
{
    public class Caracteristica : LocaAiEntityBase
    {
        public Caracteristica()
        {
            Opcoes = new List<CaracteristicaOpcao>();
            CaracteristicasPorCategorias = new List<CaracteristicaPorCategoria>();
        }

        public string Nome { get; set; }

        public List<CaracteristicaOpcao> Opcoes { get; set; }

        public List<CaracteristicaPorCategoria> CaracteristicasPorCategorias { get; set; }
    }
}
