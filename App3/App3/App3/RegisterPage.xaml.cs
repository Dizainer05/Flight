using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            passwordEntry.IsPassword = true; // Устанавливаем начальное значение свойства IsPassword у поля passwordEntry
            confirmPasswordEntry.IsPassword = true; // Устанавливаем начальное значение свойства IsPassword у поля confirmPasswordEntry
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;
            string confirmPassword = confirmPasswordEntry.Text;

            if (!IsValidEmail(username))
            {
                usernameErrorLabel.IsVisible = true; // Используем true с маленькой буквы
                return;
            }
            else
            {
                usernameErrorLabel.IsVisible = false; // Используем false с маленькой буквы
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Ошибка", "Пароли не совпадают", "OK");
                return;
            }

            string hashedPassword = HashPassword(password);

            // Save username and hashedPassword to the database
            // Implement database save logic here

            await DisplayAlert("Успех", "Регистрация прошла успешно", "OK");
            await Navigation.PopAsync();
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void OnShowPasswordCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
            passwordEntry.IsPassword = !e.Value;
            confirmPasswordEntry.IsPassword = !e.Value;
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
    }
}
