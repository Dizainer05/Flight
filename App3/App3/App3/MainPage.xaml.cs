using System;
using Xamarin.Forms;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        private bool modalOpened = false; // Флаг, отслеживающий, было ли уже открыто модальное окно
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void OnSkipClicked(object sender, EventArgs e)
        {
            
            await Navigation.PopModalAsync();// Кнопка пропустить закрытия модального окна
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Обработка нажатия кнопки Войти
            // Вставьте нужную логику для перехода на другую страницу или авторизации
            // await Navigation.PushModalAsync(new AnotherPage()); // Пример перехода на другую страницу
        }

        private async void OnLaterClicked(object sender, EventArgs e)
        {
            // Переход на страницу MainPag по нажатию на кнопку Потом
            // Закрыть текущее модальное окно
            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
            base.OnAppearing();

            // Открыть модальное окно только если оно еще не было открыто
            if (!modalOpened)
            {
                modalOpened = true;
            }
        }
    }
}
