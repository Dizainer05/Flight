using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FiltersPage : ContentPage
    {
        public FiltersPage()
        {
            InitializeComponent();

            // Подписываемся на событие Appearing для восстановления состояния при открытии модального окна
            this.Appearing += FiltersPage_Appearing;
            // Подписываемся на событие Disappearing для сохранения состояния при закрытии модального окна
            this.Disappearing += FiltersPage_Disappearing;

            // Подписываемся на событие изменения состояния переключателя "Багаж"
            SwitchBagas.Toggled += SwitchBagas_Toggled;
            // Подписываемся на событие изменения состояния переключателя "В обе стороны"
            SwitchBothWays.Toggled += SwitchBothWays_Toggled;
            // Подписываемся на событие нажатия на кнопку "Готово"
            ButtonDone.Clicked += ButtonDone_Clicked;
        }

        // Метод для восстановления состояния переключателей при открытии модального окна
        private void FiltersPage_Appearing(object sender, EventArgs e)
        {
            // Устанавливаем состояние переключателя "Багаж" при открытии модального окна
            if (Application.Current.Properties.ContainsKey("Bagas"))
            {
                SwitchBagas.IsToggled = (bool)Application.Current.Properties["Bagas"];
            }
            // Устанавливаем состояние переключателя "В обе стороны" при открытии модального окна
            if (Application.Current.Properties.ContainsKey("BothWays"))
            {
                SwitchBothWays.IsToggled = (bool)Application.Current.Properties["BothWays"];
            }
        }

        // Метод для сохранения состояния переключателей при закрытии модального окна
        private void FiltersPage_Disappearing(object sender, EventArgs e)
        {
            // Сохраняем состояние переключателя "Багаж" при закрытии модального окна
            Application.Current.Properties["Bagas"] = SwitchBagas.IsToggled;
            // Сохраняем состояние переключателя "В обе стороны" при закрытии модального окна
            Application.Current.Properties["BothWays"] = SwitchBothWays.IsToggled;
        }

        // Обработчик события изменения состояния переключателя "Багаж"
        private void SwitchBagas_Toggled(object sender, ToggledEventArgs e)
        {
            // Обновляем переменную Bagas при изменении состояния переключателя
            Application.Current.Properties["Bagas"] = e.Value;
        }

        // Обработчик события изменения состояния переключателя "В обе стороны"
        private void SwitchBothWays_Toggled(object sender, ToggledEventArgs e)
        {
            // Обновляем переменную BothWays при изменении состояния переключателя
            Application.Current.Properties["BothWays"] = e.Value;
        }

        // Обработчик события нажатия на кнопку "Готово"
        private async void ButtonDone_Clicked(object sender, EventArgs e)
        {
            // Закрываем модальное окно
            await Navigation.PopModalAsync();
        }
    }
}
