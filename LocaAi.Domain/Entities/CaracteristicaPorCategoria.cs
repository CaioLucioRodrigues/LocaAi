namespace LocaAi.Domain.Entities
{
    public class CaracteristicaPorCategoria : LocaAiEntityBase
    {
        public int CaracteristicaId { get; set; }

        public Caracteristica Caracteristica { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
