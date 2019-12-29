namespace LocaAi.Domain.Entities
{
    public class CaracteristicaOpcao : LocaAiEntityBase
    {
        public string Nome { get; set; }

        public int CaracteristicaId { get; set; }

        public Caracteristica Caracteristica { get; set; }
    }
}
