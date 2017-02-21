using ezWaiting.model;
using ezWaiting.Resx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ezWaiting
{
    // classe per modellare i vari elementi che si creano durante la creazione di un ordine.
    class AddedToMenu : INotifyPropertyChanged
    {
        private Dish dish;
        private int? quantity; //nullable int
        private double? price;
        public StringBuilder note { get; set; }
        public string variation;

        private static readonly String placeholder = AppResources.PlaceholderDish;

        public string Variation
        {
            set
            {
                if (variation != value)
                {
                    variation = value;
                    if (variation != null)
                        Prc = (dish.Price + dish.Variations[variation]) * Qnt;
                    else Prc = dish.Price * Qnt;
                }
            }
            get { return variation; }
        }

        public Dish Dis
        {
            set
            {
                if (dish.Name != value.Name)
                {
                    dish = value;
                    OnPropertyChanged("Dis");
                    Prc = dish.Price * Qnt;
                    this.Variation = null;
                    this.Qnt = 1;
                }
            }
            get { return dish; }
        }

        public int? Qnt
        {
            set
            {
                if(quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged("Qnt");
                    if (variation != null)
                        Prc = (dish.Price + dish.Variations[variation])*Qnt;
                    else Prc = dish.Price * Qnt;
                }
            }
            get { return quantity; }
        }

        public double? Prc
        {
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged("Prc");
                }
            }
            get { return price; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public AddedToMenu()
        {
            this.dish = new Dish();
            this.dish.Name = placeholder;
            this.quantity = 0;
            this.price = 0;
            this.variation = null;
            this.note = new StringBuilder();
        }

        public void AddQuantity()
        {
            if (dish.Name!="") //qui si potrebbe gestire un controllo in base alla dispensa in cucina
                Qnt = quantity + 1;
        }

        public void RemoveQuantity()
        {
            if (dish.Name != "" && quantity > 1)
                Qnt = quantity - 1;
        }

        protected void OnPropertyChanged(string propertyName)
        {
           PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // pulisco tutto una volta creato l'ordine per passare al successivo.
        public void cleaning()
        {
            this.Dis = new Dish(placeholder);
            this.Qnt = 0;
            this.Prc = 0;
            variation = null;
            note = new StringBuilder();
        }
      
    }
}
