using ezWaiting.admin;
using ezWaiting.model;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ezWaiting.admin
{
    // inizia la creazione di una sala e poi delega a CreateRoom la creazione dei tavoli.
	public partial class InsertRoom : ContentPage
	{

        private HashSet<String> placeholdersOK;
        private Restaurant restaurant;

        public InsertRoom()
        {
            InitializeComponent();
            BindingContext = this;
            this.placeholdersOK = new HashSet<string>();
            restaurant = Restaurant.Instance;
        }
        
        async void OnCreateClickedAsync(object sender, EventArgs e)
        {
            int h, w;
            if(Int32.TryParse(this.Height.Text,out h) && Int32.TryParse(this.Width.Text,out w))
                if (this.roomName.Text!=null && h>0 && w>0)
                {
                    Room r = new Room(this.roomName.Text,h,w);
                    restaurant.Rooms.Add(r);
                    await Navigation.PushAsync(new CreateRoom(r));
                }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry text = ((Entry)sender);

            if (text.Text != null && text.Text != "")
            {
                this.placeholdersOK.Add(text.Placeholder);
                if (this.placeholdersOK.Count == 3)
                {
                    this.Create.IsEnabled = true;
                }
            } else
            {
                this.placeholdersOK.Remove(text.Placeholder);
                this.Create.IsEnabled = false;
            }
        }


    }
}
