using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BitcoinCurrencyApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
       
        private void OnClicked (object sender, EventArgs arg)
        {
            DisplayAlert("Всплывающее окно", "Кнопка была нажата", "Спасибо");
        }
    }
}