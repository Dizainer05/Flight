using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            passwordEntry.IsPassword = true; // Устанавливаем начальное значение свойства IsPassword у поля passwordEntry
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (!IsValidEmail(username))
            {
                await DisplayAlert("Ошибка", "Неверный формат email", "OK");
                return;
            }

            // Implement login logic here
        }

        private async void OnRegisterLabelTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private async void OnPassengersTapped(object sender, EventArgs e)
        {
            var modalPage = new Page1();
            await Navigation.PushModalAsync(modalPage);
        }

        private async void OnFiltersTapped(object sender, EventArgs e)
        {
            var modalPage = new FiltersPage();
            await Navigation.PushModalAsync(modalPage);
        }

        private async void OnProfileButtonClicked(object sender, EventArgs e)
        {
            // Создание новой страницы профиля
            Page2 profilePage = new Page2();

            // Асинхронный переход на новую страницу
            await Navigation.PushAsync(profilePage);
        }

        private async void OnMainButtonClicked(object sender, EventArgs e)
        {
            // Создание новой страницы профиля
            MainPag MainPage = new MainPag();

            // Асинхронный переход на новую страницу
            await Navigation.PushAsync(MainPage);
        }

        private void OnShowPasswordCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
            passwordEntry.IsPassword = !e.Value;
        }
    }
}
