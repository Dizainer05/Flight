using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            // Добавляем обработчики жестов
            var regionalSettingsTap = new TapGestureRecognizer();
            regionalSettingsTap.Tapped += async (s, e) => {
                await Navigation.PushModalAsync(new RegionalSettingsPage());
            };
            RegionalSettingsLabel.GestureRecognizers.Add(regionalSettingsTap);

            var priceDisplaySettingsTap = new TapGestureRecognizer();
            priceDisplaySettingsTap.Tapped += async (s, e) => {
                await Navigation.PushModalAsync(new PriceDisplaySettingsPage());
            };
            PriceDisplaySettingsLabel.GestureRecognizers.Add(priceDisplaySettingsTap);

            var privacySettingsTap = new TapGestureRecognizer();
            privacySettingsTap.Tapped += async (s, e) => {
                await Navigation.PushModalAsync(new PrivacySettingsPage());
            };
            PrivacySettingsLabel.GestureRecognizers.Add(privacySettingsTap);
            

        }

        async void OnLoginPage(object sender, EventArgs args)
        {
            Login logins = new Login();

            // Асинхронный переход на новую страницу
            await Navigation.PushAsync(logins);
        }
        private async void OnMainButtonClicked(object sender, EventArgs e)
        {
            // Создание новой страницы профиля
            MainPag MainPage = new MainPag();

            // Асинхронный переход на новую страницу
            await Navigation.PushAsync(MainPage);
        }
    }
}