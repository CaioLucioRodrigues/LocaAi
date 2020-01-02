using LocaAi.Presentation.Mobile.Models;
using LocaAi.Presentation.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocaAi.Presentation.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItensPropriosPage : ContentPage
    {
        public ItensPropriosViewModel ViewModel { get; set; }

        public ItensPropriosPage()
        {
            InitializeComponent();
            ViewModel = new ItensPropriosViewModel();
            BindingContext = ViewModel;
        }

        private void listViewItensProprios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var produto = (Produto)e.Item;
            Navigation.PushAsync(new DetalhesItemView(produto));
        }
    }
}