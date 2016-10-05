﻿using BitcoinCurrencyApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BitcoinCurrencyApp
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var content = new CurrencyPage();
            MainPage = new NavigationPage(content);
            //    new ContentPage
            //{
            //    Title = "BitcoinCurrencyApp",
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                HorizontalTextAlignment = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
