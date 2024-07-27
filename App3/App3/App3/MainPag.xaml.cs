using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPag : ContentPage
    {
        public DateTime SelectedDate { get; set; }
        public MainPag()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            // Подписка на сообщение для обновления количества пассажиров и класса
            MessagingCenter.Subscribe<Page1, string>(this, "UpdatePassengerClassLabel", (sender, arg) =>
            {
                PassengerClassLabel.Text = arg;
            });
        }

        private async void ShowModalAfterDelay()
        {
            await Task.Delay(5000);
            var modalPage = new MainPage();
            await Navigation.PushModalAsync(modalPage);
        }

        private DateTime departureDate;
        private DateTime returnDate;

        private async void OnDatesTapped(object sender, EventArgs e)
        {
            // Загрузка сохраненных дат, если они есть
            if (Application.Current.Properties.ContainsKey("DepartureDate"))
            {
                departureDate = (DateTime)Application.Current.Properties["DepartureDate"];
            }
            else
            {
                departureDate = DateTime.Now;
            }

            if (Application.Current.Properties.ContainsKey("ReturnDate"))
            {
                returnDate = (DateTime)Application.Current.Properties["ReturnDate"];
            }
            else
            {
                returnDate = DateTime.Now.AddDays(1);
            }

            var departureDatePicker = new DatePicker
            {
                Date = departureDate,
                MinimumDate = DateTime.Now,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#1c1c1e"),
                Format = "dd MMMM yyyy"
            };

            var returnDatePicker = new DatePicker
            {
                Date = returnDate,
                MinimumDate = departureDate.AddDays(1),
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#1c1c1e"),
                Format = "dd MMMM yyyy"
            };

            departureDatePicker.DateSelected += (s, args) =>
            {
                if (returnDatePicker.Date <= departureDatePicker.Date)
                {
                    returnDatePicker.Date = departureDatePicker.Date.AddDays(1);
                }
                returnDatePicker.MinimumDate = departureDatePicker.Date.AddDays(1);
            };

            var acceptButton = new Button
            {
                Text = "Сохранить",
                BackgroundColor = Color.FromHex("#3c8302"),
                TextColor = Color.White,
                CornerRadius = 10,
                FontSize = 18,
                TextTransform = TextTransform.None,
                FontFamily = "Roboto-Medium",
                Margin = new Thickness(0, 40, 0, 0)
            };
            acceptButton.Clicked += async (s, args) =>
            {
                // Сохранение выбранных дат
                Application.Current.Properties["DepartureDate"] = departureDatePicker.Date;
                Application.Current.Properties["ReturnDate"] = returnDatePicker.Date;
                await Application.Current.SavePropertiesAsync();

                await Navigation.PopModalAsync();
            };

            var stackLayout = new StackLayout
            {
                BackgroundColor = Color.FromHex("#1c1c1e"),
                Padding = new Thickness(20),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
            new Label { Text = "Дата отлета", TextColor = Color.White },
            departureDatePicker,
            new Label { Text = "Дата прилета", TextColor = Color.White, Margin = new Thickness(0, 20, 0, 0) },
            returnDatePicker,
            acceptButton
        }
            };

            var modalPage = new ContentPage
            {
                Content = new Frame
                {
                    Content = stackLayout,
                    BackgroundColor = Color.FromHex("#1c1c1e"),
                    CornerRadius = 20, // Закругленные углы формы
                    Margin = new Thickness(40,200) // Увеличенный отступ для уменьшения размера формы
                },
                BackgroundColor = Color.FromHex("#242424"),
                Title = "Выберите даты"
            };


            await Navigation.PushModalAsync(modalPage);
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
