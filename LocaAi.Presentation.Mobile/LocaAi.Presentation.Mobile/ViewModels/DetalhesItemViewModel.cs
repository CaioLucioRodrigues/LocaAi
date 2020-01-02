using LocaAi.Presentation.Mobile.Models;

namespace LocaAi.Presentation.Mobile.ViewModels
{
    public class DetalhesItemViewModel : BaseViewModel
    {
        public Produto Produto { get; set; }

        public DetalhesItemViewModel(Produto produto)
        {
            Produto = produto;
        }
    }
}
