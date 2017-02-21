using ezWaiting.model;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ezWaiting
{
    // popup per impostare i coperti a un tavolo
    public partial class SetSeatsPopup : PopupPage, INotifyPropertyChanged
    {
        public int Seats { get; set; }
        public int MaxSeats { get; set; }
        public Table Table { get; set; }
        private bool ReSetSeats { get; set; } // se sto reimpostando i posti a sedere

        /* usato perche' la classe e' buggata e non funziona await, 
         * quindi devo gestire la terminazione del popup con un evento */
        public event EventHandler Terminated;

        public SetSeatsPopup(Table t, bool reSetSeats)
        {
            this.MaxSeats = t.Seats;
            if (!reSetSeats)
            {
                this.Seats = 1;
            }
            else
            {
                this.Seats = t.Occupants.OccupiedSeats;
            }
            this.Table = t;
            this.ReSetSeats = reSetSeats;
            InitializeComponent();

            BindingContext = this;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            //return base.OnBackButtonPressed();
            return true;
        }

        // aggiungo o rimuovo posti (premo + o - )
        private void StepperChanged(object sender, ValueChangedEventArgs e)
        {
            OnPropertyChanged("Seats");
        }

        void OnOKClicked(object sender, EventArgs e)
        {
            if (this.Seats != 0)
            {
                OccupiedTable occupiedTable = new OccupiedTable(Table, this.Seats);
                Table.Occupants = occupiedTable;
                Table.Occupied = true;
                Navigation.PopPopupAsync();
                if (!ReSetSeats)
                {
                    // lo metto qui perche' la classe per i popup e' buggata e non funziona await nella precedente
                    Navigation.PushAsync(new ezWaiting.TablePage(Table));

                }
                else Terminated(this, null);
            }

        }

        async void OnCancelClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}
