using ezWaiting.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ezWaiting
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var ezWaitingPage = new LoginPage();
            //var ezWaitingPage = new WaiterPage(); da usare nel debug, per non fare sempre il login
            //var ezWaitingPage = new AdminHome();
            NavigationPage n = new NavigationPage(ezWaitingPage);
            n.BarTextColor = Color.White;
            n.BarBackgroundColor = Color.FromHex("1976D2");
            MainPage = n;
        }
        
    }
}
