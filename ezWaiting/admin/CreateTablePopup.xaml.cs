using ezWaiting.model;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ezWaiting.admin
{
    // popup per impostare i parametri di un tavolo
    public partial class CreateTablePopup : PopupPage
    {
        public Table table { get; set; }
        public int Seats { get; set; }
        public String Name { get; set; }
        //usato perche' la classe e' buggata e non funziona await, quindi genero un evento al termine del popup.
        public event EventHandler Terminated; 

        public CreateTablePopup(Table t)
        {
            InitializeComponent();
            table = t;
            Seats = 1;
            BindingContext = this;
        }

        async void OnCompleted(object sender, EventArgs e)
        {
            table.Name = Name;
            table.Seats = Seats;
            await Navigation.PopPopupAsync();
            Terminated(this, null);
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            String text = ((Entry)sender).Text;
            OkButton.IsEnabled = (text != null && text != "");
        }

        async void OnCancel(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            //return base.OnBackButtonPressed();
            return true;
        }

        private void StepperChanged(object sender, ValueChangedEventArgs e)
        {
            OnPropertyChanged("Seats");
        }
    }
}
