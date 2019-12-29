namespace LocaAi.Domain.Entities
{
    public class Produto : LocaAiEntityBase
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int UsuarioId { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public Usuario Usuario { get; set; }
    }
}
