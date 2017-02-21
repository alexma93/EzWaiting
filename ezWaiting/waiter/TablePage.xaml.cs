using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ezWaiting.model;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Extensions;
using System.ComponentModel;
using ezWaiting.Resx;

namespace ezWaiting
{
    // pagina che visualizza un tavolo, le sue portate e ne aggiunge altre.
	public partial class TablePage : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<Course> courses;
        public Table table;
        public Course lastCourse; // una nuova portata che si sta creando
        public int seats { get; set; }


        public TablePage (Table table)
        {
            this.Title = AppResources.Table + " " + table.Name;
            this.courses = new ObservableCollection<Course>(table.Occupants.Courses);
            this.table = table;
            this.seats = this.table.Occupants.OccupiedSeats;
            InitializeComponent();

            OrdersView.ItemsSource = this.courses;
            BindingContext = this;
        }

        // libera il tavolo
        async public void OnFreeClickedAsync(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(AppResources.SureQuestion, null, AppResources.Yes, AppResources.No);
            if (answer)
            {
                table.FreeTable();
                await Navigation.PopAsync();
            }
        }

        // reimposto i posti a sedere.
        async public void OnToolbarItemClicked(object sender, EventArgs e)
        {
            var popup = new SetSeatsPopup(this.table, true);
            popup.Terminated += Popup_Terminated;
            await Navigation.PushPopupAsync(popup);
        }
        // richiamato una volta settati i posti a sedere.
        private void Popup_Terminated(object sender, EventArgs e)
        {
            this.seats = this.table.Occupants.OccupiedSeats;
            OnPropertyChanged("seats");
        }

        async private void CreateNewCourse(object sender, EventArgs args)
        {
            this.lastCourse = new Course(this.courses.Count+1);
            var menuPage = new MenuPage(this.lastCourse);
            menuPage.CourseCompleted += HandlecourseCompleted;
            await Navigation.PushAsync(menuPage);
        }
        // richiamato quando una pprtata e' completata.
        private async void HandlecourseCompleted(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            this.courses.Add(lastCourse);
            this.table.Occupants.Courses.Add(lastCourse);

        }

        // seleziona la portata da visualizzare
        public async void OnCourseSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            ((ListView)sender).SelectedItem = null; // de-select the row
            if (e.SelectedItem == null)
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            Course c = (Course)e.SelectedItem;
            await Navigation.PushAsync(new CoursePage(c));
        }

    }
}
