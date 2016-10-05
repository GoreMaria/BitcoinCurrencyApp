using BitcoinCurrencyApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BitcoinCurrencyApp.View
{
    public partial class CurrencyPage : ContentPage
    {
        CurrencyViewModel vm;
        public CurrencyPage()
        {
            InitializeComponent();

            vm = new CurrencyViewModel();
            BindingContext = vm;
        }
    }
}
