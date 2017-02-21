using ezWaiting.model;
using ezWaiting.Resx;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ezWaiting.admin
{
    // classe usata per creare o modificare i tavoli in una sala
    public partial class CreateRoom : ContentPage
    {
        public Room Room { get; set; }
        public Table[,] SelectedPlace { get; set; } // i tavoli creati
        private Image selectedImage; // l'immagine del tavolo selezionato

        private Grid Grid;
        private Dictionary<Tuple<int, int>, Label> showedLabel; // le label dei nomi dei tavoli creati

        public CreateRoom(Room r)
        {
            InitializeComponent();
            Room = r;
            /* creo una griglia dinamicamente a seconda delle dimensioni della sala */
            Grid = new Grid();
            Grid.HorizontalOptions = LayoutOptions.FillAndExpand;
            Grid.VerticalOptions = LayoutOptions.FillAndExpand;
            showedLabel = new Dictionary<Tuple<int, int>, Label>();
            this.MainLayout.Children.Add(Grid);
            this.SelectedPlace = new Table[r.Width, r.Height];
            for (int i = 0; i < r.Width; i++)
                Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            for (int j = 0; j < r.Height; j++)
                Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += B_Clicked;
            // creo i tavoli e li colloco nella griglia
            for (int i = 0; i < r.Width; i++)
                for (int j = 0; j < r.Height; j++)
                {
                    Image im = new Image
                    {
                        Aspect = Aspect.AspectFit,
                    };
                    Table existedTable = Room.getTableFromCoordinates(i, j);
                    Grid.Children.Add(im, i, j);
                    if (existedTable != null)
                    {
                        im.Source = "table";
                        Label label = addTableLabel(existedTable,i,j);
                        SelectedPlace[i, j] = existedTable;
                        Grid.Children.Add(label,i,j);
                    }
                    else im.Source = "tableWhite";
                    im.BindingContext = new Tuple<int, int>(i, j);
                    im.GestureRecognizers.Add(tapGestureRecognizer);
                }

        }

        // se ho cliccato un tavolo
        private async void B_Clicked(object sender, EventArgs e)
        {
            Image im = (Image)sender;

            Tuple<int, int> t = (Tuple<int, int>)im.BindingContext;
            if (SelectedPlace[t.Item1, t.Item2] == null)
            {
                selectedImage = im;
                
                Table tab = new Table {
                    Coordinates = new Point(t.Item1, t.Item2)
                };
                var popup = new CreateTablePopup(tab);
                popup.Terminated += Popup_Terminated;
                await Navigation.PushPopupAsync(popup);
                
            }
            else // se clicco un tavolo gia' creato lo rimuovo
            {
                im.Source = "tableWhite";
                Grid.Children.Remove(showedLabel[t]);
                SelectedPlace[t.Item1, t.Item2] = null;
            }
        }

        // eseguito una volta conclusa la creazione di un tavolo
        private void Popup_Terminated(object sender, EventArgs e)
        {
            CreateTablePopup tabPop = (CreateTablePopup)sender;
            Table tab = tabPop.table;
            int x = Convert.ToInt32(tab.Coordinates.X);
            int y = Convert.ToInt32(tab.Coordinates.Y);
            Label label = addTableLabel(tab,x,y);
            SelectedPlace[x,y] = tab;
            selectedImage.Source = "table";
        }

        private Label addTableLabel(Table t,int x,int y)
        {
            Label label = new Label
            {
                Text = t.Name,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.Black,
                FontSize = 17,
                FontAttributes = FontAttributes.Bold,
            };
            showedLabel[new Tuple<int, int>(x,y)] = label;
            Grid.Children.Add(label, Convert.ToInt32(t.Coordinates.X), Convert.ToInt32(t.Coordinates.Y));
            return label;
        }

        async void OnFinishAsync(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(AppResources.SureQuestion, null, AppResources.Yes, AppResources.No);
            if (answer)
            {
                Room.Tables = new List<Table>(); //azzero tutto e poi reinserisco, che l'utente potrebbe aver modificato ogni cosa
                foreach (Table t in SelectedPlace)
                {
                    if (t != null)
                        Room.addTable(t);
                }
                await Navigation.PopToRootAsync();
            }
        }
    }

}

