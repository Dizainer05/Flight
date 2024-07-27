using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegionalSettingsPage : ContentPage
    {
        public RegionalSettingsPage()
        {
            InitializeComponent();
        }
        private async void CloseModal(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}