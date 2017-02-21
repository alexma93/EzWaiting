using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ezWaiting
{
	public partial class NotePage : PopupPage, INotifyPropertyChanged
    {
        StringBuilder Str { get; set; } // stringBuilder da' side-effect e quindi corrisponde alla nota che si sta inserendo 
        String Text { get; set; } // memorizza il testo che sto inserendo
        
        public NotePage (String title,StringBuilder s)
		{
			InitializeComponent ();

            this.Title = title;
            this.Str = s;
            this.Text =s.ToString();
            BindingContext = this.Text;
		}

        void OnCompleted(object sender, EventArgs e)
        {
            this.Text = ((Entry)sender).Text;
            if (this.Text!="")
            {
                this.Str.Clear();
                this.Str.Append(this.Text);
                Navigation.PopPopupAsync();
            }
        }

        async void OnCancel(object sender, EventArgs e)
        {
           await Navigation.PopPopupAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            //return base.OnBackButtonPressed();
            return true;
        }

    }
}
