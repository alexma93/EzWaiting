
using ezWaiting.model;
using ezWaiting.Resx;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace ezWaiting
{
    // mostra una portata come un elenco di ordini
    public partial class CoursePage : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<Order> Orders { get; set; }
        public Course course;

        private Order currOrd; // l'ordine selezionato
        private string note;

        public Order CurrentOrder
        {
            get { return currOrd; }
            set
            {
                if (value != null)
                    this.Note = value.Note;
                else this.Note = null;
                currOrd = value;
            }
        }

        public string Note
        {
            get { return note; }
            set
            {
                if (note != value)
                {
                    note = value;
                    OnPropertyChanged("Note");
                }

            }
        }

        private double? total;
        public double? Total
        {
            get { return total; }
            set
            {
                if (total != value)
                {
                    total = value;
                    OnPropertyChanged("Total");
                }
            }
        }

        public event EventHandler OrdersEmpty; // quando ho eliminato tutti gli ordini; il subscriber viene dalla menu page.
        public event EventHandler OrdersChanged; // quando e' cambiato il numero di ordini
        public event EventHandler SelectedChanged; // quando seleziono un ordine

        public CoursePage(Course c)
        {
            InitializeComponent();
            this.Title = String.Format(AppResources.CourseNum, c.Number);
            this.course = c;
            this.Orders = new ObservableCollection<Order>(c.Orders);
            OrdersChanged += CoursePage_ordersChanged;
            SelectedChanged += CoursePage_selectedChanged;
            Total = (from o in this.Orders select o.Price).Sum();
            BindingContext = this;
            if (this.Orders.Count == 0)
                DeleteButton.IsEnabled = false;
        }

        private void CoursePage_selectedChanged(object sender, EventArgs e)
        {
            SelectedChanged(this, new PropertyChangedEventArgs("Note"));
        }

        private void CoursePage_ordersChanged(object sender, EventArgs e)
        {
            OrdersChanged(this, new PropertyChangedEventArgs("Total"));
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            if (e.SelectedItem == null)
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            this.CurrentOrder = (Order)e.SelectedItem;
        }

        public void OnOpenAllergens(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Dish d = (Dish)mi.CommandParameter;
            if (d.HasAllergens())
                DisplayAlert(AppResources.Allergens + " " + d.Name + ":", d.GetStringAllergens(), AppResources.Ok);
            else DisplayAlert(AppResources.Allergens + " " + d.Name + ":", AppResources.None, AppResources.Ok);
        }

        public void OnOpenIngredients(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Dish d = (Dish)mi.CommandParameter;
            if (d.Ingredients.Any())
                DisplayAlert(AppResources.Ingredients + " " + d.Name + ":", d.GetStringIngredients(), AppResources.Ok);
            else DisplayAlert(AppResources.Ingredients + " " + d.Name + ":", AppResources.None, AppResources.Ok);
        }


        void OnDeleteClicked(object sender, EventArgs e)
        {
            if (CurrentOrder != null)
            {
                // tolgo dalla lista corrente per la visualizzazione, ma anche da quella reale
                this.Orders.Remove(this.CurrentOrder);
                this.course.Orders.Remove(this.CurrentOrder);
                this.CurrentOrder = null;
                Total = (from o in this.Orders select o.Price).Sum();
                if(this.Orders.Count==0) {
                    OrdersEmpty(this, EventArgs.Empty);
                    DeleteButton.IsEnabled = false;
                }
                OrdersList.SelectedItem = null;
            }

        }


    }
}
