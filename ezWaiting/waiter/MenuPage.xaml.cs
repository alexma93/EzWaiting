using System;
using System.Linq;
using ezWaiting.model;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using ezWaiting.Resx;
using Rg.Plugins.Popup.Extensions;

namespace ezWaiting
{
    // gestisce il menu per un cameriere durante la creazione di una portata
	public partial class MenuPage : ContentPage
    {
        public ObservableCollection<Category> ListCategories { get; set; }
        public Course Course { get; set; }

        public event EventHandler CourseCompleted; // gestito in tablePage

        public MenuPage (Course c)
		{
			InitializeComponent ();
            Restaurant restaurant = Restaurant.Instance;
            this.ListCategories = new ObservableCollection<Category>(restaurant.Categories);
            CarouselView.ItemsSource = restaurant.Categories;
            this.Course = c;

        }

        // terminata la portata
        void OnEndAsync(object sender, EventArgs e)
        {
            if (Course.Orders.Count > 0)
            {
                CourseCompleted(this, EventArgs.Empty);
            }
        }

        // selezionato un piatto dal menu
        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            ((ListView)sender).SelectedItem = null; // de-select the row
            if (e.SelectedItem == null)
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            Dish d = (Dish)e.SelectedItem;
            itemAdder.Dis = d;
            OkButton.IsEnabled = true;
            if (d.Variations.Count > 0)
                VariantButton.IsEnabled = true;
            else VariantButton.IsEnabled = false;
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

        void OnMinusClicked(object sender, EventArgs e)
        {
            itemAdder.RemoveQuantity();
        }


        void OnPlusClicked(object sender, EventArgs e)
        {
            itemAdder.AddQuantity();
        }

        async void OnNoteClickedAsync(object sender, EventArgs e)
        {
            if(itemAdder.Dis.Name!="")
                await Navigation.PushPopupAsync(new NotePage(itemAdder.Dis.Name,itemAdder.note));
        }

        async void OnVariationClickedAsync(object sender, EventArgs e)
        {
            if (itemAdder.Dis.Name != "" && itemAdder.Dis.Variations.Count>0)
            {
                String[] variations = itemAdder.Dis.Variations.Keys.ToArray();
                var variation = await DisplayActionSheet(itemAdder.Dis.Name, AppResources.Cancel, AppResources.Remove, variations);
                if(variation!= AppResources.Cancel)
                    if(variation!= AppResources.Remove)
                        itemAdder.Variation = variation;
                    else itemAdder.Variation = null;
            }
        }

        void OnOkClicked(object sender, EventArgs e)
        {
            if(itemAdder.Qnt>0)
            {
                Order o = new Order{
                    Dish = itemAdder.Dis,
                    Quantity = itemAdder.Qnt.Value,
                    Variation = itemAdder.variation,
                    Note = itemAdder.note.ToString()
                };
                this.Course.Orders.Add(o);
                itemAdder.cleaning();
                OkButton.IsEnabled = false;
                VariantButton.IsEnabled = false;
                EndButton.IsEnabled = true;
            }


        }

        // visualizzo la portata che sto creando
        async void OnCourseClickedAsync(object sender, EventArgs e)
        {
            var CoursePage = new ezWaiting.CoursePage(Course);
            CoursePage.OrdersEmpty += endButtonDisable;
            await Navigation.PushAsync(CoursePage);
        }
        // richiamato quando elimino tutti gli ordini che sto creando. disabilito il tasto end.
        private  void endButtonDisable(object sender, EventArgs e)
        {
            if(Course.Orders.Count==0)
                EndButton.IsEnabled = false;

        }




    }


}
