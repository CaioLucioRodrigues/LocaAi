using LocaAi.Presentation.Mobile.Views;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace LocaAi.Presentation.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnItensClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItensPropriosPage());
        }
    }
}
