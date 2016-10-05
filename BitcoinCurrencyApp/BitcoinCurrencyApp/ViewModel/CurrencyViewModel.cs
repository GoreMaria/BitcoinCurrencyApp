using BitcoinCurrencyApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BitcoinCurrencyApp.ViewModel
{
    public class CurrencyViewModel : INotifyPropertyChanged //is important for data binding in MVVM Frameworks. 
        //This is an interface that, when implemented, lets our view know about changes to the model.
    {
        //Interface implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Currency> Currency { get; set; }
        
        //interface handler
        //we can call OnPropertyChanged(); whenever a property updates
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        

        //Instead of invoking this method directly, we will expose it with a Command. 
        //A Command has an interface that knows what method to invoke 
        //and has an optional way of describing if the Command is enabled.
        //Create a new Command called GetCurrencyCommand:
      public Command GetCurrencyCommand { get; set; }
       

        private bool busy;

        //Notice that we call OnPropertyChanged(); whenever the value changes. 
        //The Xamarin.Forms binding infrastructure will subscribe to our PropertyChanged event so the UI will get notified of the change.
        public bool IsBusy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
                //Update the can execute
                GetCurrencyCommand.ChangeCanExecute();
            }
        }
        
        //Constructor
        public CurrencyViewModel()
        {
            Currency = new ObservableCollection<Currency>();

            //create the GetSpeakersCommand and pass it two methods: 
            //one to invoke when the command is executed and another that determines whether the command is enabled.
            //Both methods can be implemented as lambda
            GetCurrencyCommand=new Command(async()=>await GetCurrency(),()=>!IsBusy);

        }

        //set to create a method named GetCurrency which will retrieve the speaker data from the internet. 
        //We will implement this with a simply HTTP request

        private async Task GetCurrency()
        {
            //check if we are already grabbing data
            if (IsBusy)
                return;
            
            //scaffolding for try/catch/finally blocks
            Exception error = null;
            try
            {
                IsBusy = true;
                using (var client = new HttpClient())
                { //grab json from server
                    var json = await client.GetStringAsync("https://bitpay.com/api/rates/");

                    //we will Deserialize the json and turn it into a list of Speakers with Json.NET

                    var items = JsonConvert.DeserializeObject<List<Currency>>(json);

                    //we will clear the speakers and then load them into the ObservableCollection

                    Currency.Clear();
                    foreach (var item in items)
                        Currency.Add(item);
                    
                }

            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }
            if (error != null)
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
        }
    }
}
