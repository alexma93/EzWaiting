using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ezWaiting.model;
using ezWaiting.Resx;
using ezWaiting.admin;

namespace ezWaiting
{
	public partial class LoginPage : ContentPage
	{
        public string Username { get; set; }
        public string Password { get; set; }

        private bool isUsername;
        private bool isPassword;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;
            this.isPassword = false;
            this.isUsername = false;
        }

        void OnLoginClicked(object sender, EventArgs e)
        {
            this.Username = this.UserEntry.Text;
            this.Password = this.PassEntry.Text;
            if (this.Username != null && this.Password != null)
            {
                Person p = null;
                Restaurant.Instance.People.TryGetValue(this.Username,out p);
                if (p != null && p.Password == this.Password)
                {
                    if(p.IsAdmin)
                        Navigation.PushAsync(new AdminHome());
                    else Navigation.PushAsync(new WaiterPage());
                    Navigation.RemovePage(this);
                }
                else
                {
                    DisplayAlert(AppResources.Error, AppResources.LoginErr, AppResources.Ok);
                }
            }
        }

        private void TextChangedPassword(object sender, TextChangedEventArgs e)
        {
            String text = ((Entry)sender).Text;

            this.isPassword = (text != null && text != "");

            this.Login.IsEnabled = (this.isPassword && this.isUsername);
        }

        private void TextChangedUsername(object sender, TextChangedEventArgs e)
        {
            String text = ((Entry)sender).Text;

            this.isUsername = (text != null && text != "");

            this.Login.IsEnabled = (this.isPassword && this.isUsername);
        }
    }
}
