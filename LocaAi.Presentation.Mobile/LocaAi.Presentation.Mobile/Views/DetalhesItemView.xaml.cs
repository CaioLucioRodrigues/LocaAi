using LocaAi.Presentation.Mobile.Models;
using LocaAi.Presentation.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocaAi.Presentation.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesItemView : ContentPage
    {
        public DetalhesItemViewModel ViewModel { get; set; }

        public DetalhesItemView(Produto produto)
        {
            InitializeComponent();
            ViewModel = new DetalhesItemViewModel(produto);
            BindingContext = ViewModel;
        }
    }
}