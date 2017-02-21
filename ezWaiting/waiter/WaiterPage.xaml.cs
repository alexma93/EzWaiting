using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ezWaiting.model;

namespace ezWaiting
{
    // la pagina iniziale di un cameriere contiene le varie sale.
    public partial class WaiterPage : TabbedPage
    { 
        public WaiterPage()
        {
            InitializeComponent();
            Restaurant restaurant = Restaurant.Instance;
            foreach(Room elem in restaurant.Rooms)
                Children.Add(new RoomPage(elem));
            
        }



    }
}
