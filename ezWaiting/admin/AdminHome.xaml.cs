using ezWaiting.model;
using ezWaiting.Resx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ezWaiting.admin
{
    public partial class AdminHome : ContentPage
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (Restaurant.Instance.Rooms.Count == 0)
                ModifyButton.IsEnabled = false;
            else ModifyButton.IsEnabled = true;
        }

        // crea una nuova sala
        void OnInsertRoomAsync(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertRoom());
        }

        // modifica una vecchia sala
        void OnModifyRoomAsync(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModifyRoom());
        }

        // servi ai tavoli
        void OnTablesAsync(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WaiterPage());
        }

        async void OnLogoutAsync(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(AppResources.LogoutQuestion, null, AppResources.Yes, AppResources.No);
            if (answer)
            {
                await Navigation.PushAsync(new LoginPage());
                Navigation.RemovePage((Page)this);
            }
        }


    }
}
