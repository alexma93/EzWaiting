using ezWaiting.model;
using ezWaiting.Resx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ezWaiting.admin
{
    // menu per modificare o eliminare le sale.
    public partial class ModifyRoom : ContentPage
    {
        public  ObservableCollection<Room> Rooms { get; set; }

        public ModifyRoom()
        {
            InitializeComponent();
            // creo una nuova collezione per non rendere le rooms del mock ObservableCollection
            Rooms = new ObservableCollection<Room>(Restaurant.Instance.Rooms);
            BindingContext = this;
        }

        // selezionata una sala
        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            Room r = (Room)(sender as ListView).SelectedItem;
            var action = await DisplayActionSheet(r.Name, "Cancel", null, AppResources.Modify, AppResources.Delete);
            if (action == AppResources.Delete)
                deleteRoom(r);
            else if (action == AppResources.Modify)
                await Navigation.PushAsync(new CreateRoom(r));
            ((ListView)sender).SelectedItem = null;
        }

        public async void deleteRoom(Room r)
        {
            var answer = await DisplayAlert(AppResources.SureDeleteQuestion, null, AppResources.Yes, AppResources.No);
            if (answer)
            {
                Rooms.Remove(r);
                Restaurant.Instance.Rooms.Remove(r);
            }
        }
    }
}
