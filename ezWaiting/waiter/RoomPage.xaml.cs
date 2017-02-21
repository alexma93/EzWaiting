using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ezWaiting.model;
using Rg.Plugins.Popup.Extensions;
using System.Collections.ObjectModel;
using ezWaiting.Resx;

namespace ezWaiting
{
	public partial class RoomPage : ContentPage
	{
        public Collection<Table> Tables { get; set; } 
        private Dictionary<Table,Image> TableToImage { get; set; }

        public RoomPage (Room room)
		{
			InitializeComponent();
            this.Tables = new Collection<Table>(room.Tables);
            this.TableToImage = new Dictionary<Table, Image>();
            this.Title = room.Name;
            if(Device.OS== TargetPlatform.iOS)
                this.Icon = "tableWhite";
            BindingContext = this;

            
            for (int i = 0; i < room.Width; i++)
                roomGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            for (int j = 0; j < room.Height; j++)
                roomGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            Table t = null;
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Image_TappedAsync;
            for (int i = 0; i < room.Width; i++)
                for (int j = 0; j < room.Height; j++)
                {
                    if (this.Tables.Any(table => { t = table; return table.Coordinates.X == i && table.Coordinates.Y == j; }))
                    {
                        Image im = new Image
                        {
                            Aspect = Aspect.AspectFit,
                        };
                        if (t.Occupied)
                            im.Source = "tablered";
                        else im.Source = "table";
                        im.BindingContext = t;
                        this.TableToImage[t] = im;
                        t.PropertyChanged += T_PropertyChanged;
                        roomGrid.Children.Add(im, i, j);
                        Label label = new Label
                        {
                            Text = t.Name,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            TextColor = Color.Black,
                            FontSize = 17,
                            FontAttributes = FontAttributes.Bold,
                            
                        };
                        roomGrid.Children.Add(label, i, j);
                        im.GestureRecognizers.Add(tap);
                    }
                }

        }

        private void T_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Table t = sender as Table;
            if (t.IsFree())
            {
                Image im = TableToImage[t];
                im.Source = "table.png";
            } else
            {
                Image im = TableToImage[t];
                im.Source = "tablered.png";
            }
            
        }

        private async void Image_TappedAsync(object sender, EventArgs e)
        {
            Image im = sender as Image;
            Table t = (Table)im.BindingContext;
            if (t.IsFree())
            {
                await Navigation.PushPopupAsync(new SetSeatsPopup(t, false));
            }
            else
                await Navigation.PushAsync(new ezWaiting.TablePage(t));
        }
        

        async public void OnToolbarItemClickedAsync(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(AppResources.LogoutQuestion,null, AppResources.Yes, AppResources.No);
            if(answer)
            {
                await Navigation.PushAsync(new LoginPage());
                Navigation.RemovePage((Page)this.Parent);
            }
        }

    }
}
