//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ezWaiting {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class MenuPage : global::Xamarin.Forms.ContentPage {
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::CarouselView.FormsPlugin.Abstractions.CarouselViewControl CarouselView;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::ezWaiting.AddedToMenu itemAdder;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(MenuPage));
            CarouselView = this.FindByName<global::CarouselView.FormsPlugin.Abstractions.CarouselViewControl>("CarouselView");
            itemAdder = this.FindByName<global::ezWaiting.AddedToMenu>("itemAdder");
        }
    }
}
