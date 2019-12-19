using LocaAi.Presentation.Mobile.Models;
using System.Collections.Generic;

namespace LocaAi.Presentation.Mobile.ViewModels
{
    public class ItensPropriosViewModel : BaseViewModel
    {
        public List<Produto> Produtos { get; set; }

        public ItensPropriosViewModel()
        {
            Produtos = new List<Produto>()
            {
                new Produto() { Nome = "Furadeira Philco" },
                new Produto() { Nome = "Vap Karcher" }
            };
        }
    }
}
