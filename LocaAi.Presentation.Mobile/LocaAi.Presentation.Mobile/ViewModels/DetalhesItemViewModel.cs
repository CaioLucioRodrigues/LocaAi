using LocaAi.Presentation.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
