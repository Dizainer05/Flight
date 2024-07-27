using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new Page2();
            MainPage = new NavigationPage(new MainPag());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            // Сохраняем все данные при переходе приложения в режим ожидания
            Application.Current.SavePropertiesAsync();
        }

        protected override void OnResume()
        {
        }
    }
}
