using Xamarin.Forms;

namespace App3
{
    public partial class Page1 : ContentPage
    {
        int adults = 1;
        int children = 0;
        int infants = 0;
        string selectedClass = "Эконом";
 

        public Page1()
        {
            InitializeComponent();

            // Подписываемся на события Appearing и Disappearing для сохранения и восстановления состояния
            this.Appearing += Page1_Appearing;
            this.Disappearing += Page1_Disappearing;

            // Инициализируем надпись при запуске
            UpdateSummaryLabel();
        }

        private void Page1_Appearing(object sender, System.EventArgs e)
        {
            // Восстанавливаем состояние при открытии страницы
            if (Application.Current.Properties.ContainsKey("Adults"))
            {
                AdultsLabel.Text = Application.Current.Properties["Adults"].ToString();
            }
            if (Application.Current.Properties.ContainsKey("Children"))
            {
                ChildrenLabel.Text = Application.Current.Properties["Children"].ToString();
            }
            if (Application.Current.Properties.ContainsKey("Infants"))
            {
                InfantsLabel.Text = Application.Current.Properties["Infants"].ToString();
            }
            if (Application.Current.Properties.ContainsKey("SelectedClass"))
            {
                selectedClass = Application.Current.Properties["SelectedClass"].ToString();
                UpdateSelectedClass();
            }

            UpdateSummaryLabel();
        }

        private void Page1_Disappearing(object sender, System.EventArgs e)
        {
            // Сохраняем состояние при закрытии страницы
            Application.Current.Properties["Adults"] = AdultsLabel.Text;
            Application.Current.Properties["Children"] = ChildrenLabel.Text;
            Application.Current.Properties["Infants"] = InfantsLabel.Text;
            Application.Current.Properties["SelectedClass"] = selectedClass;
        }

        void OnIncreaseAdults(object sender, System.EventArgs e)
        {
            int adults = int.Parse(AdultsLabel.Text);
            if (adults < 9)
            {
                adults++;
                AdultsLabel.Text = adults.ToString();
                UpdateSummaryLabel();
            }
        }

        void OnDecreaseAdults(object sender, System.EventArgs e)
        {
            int adults = int.Parse(AdultsLabel.Text);
            if (adults > 1)
            {
                adults--;
                AdultsLabel.Text = adults.ToString();
                UpdateSummaryLabel();
            }
        }

        void OnIncreaseChildren(object sender, System.EventArgs e)
        {
            int children = int.Parse(ChildrenLabel.Text);
            if (children < 9)
            {
                children++;
                ChildrenLabel.Text = children.ToString();
                UpdateSummaryLabel();
            }
        }

        void OnDecreaseChildren(object sender, System.EventArgs e)
        {
            int children = int.Parse(ChildrenLabel.Text);
            if (children > 0)
            {
                children--;
                ChildrenLabel.Text = children.ToString();
                UpdateSummaryLabel();
            }
        }

        void OnIncreaseInfants(object sender, System.EventArgs e)
        {
            int infants = int.Parse(InfantsLabel.Text);
            if (infants < 9)
            {
                infants++;
                InfantsLabel.Text = infants.ToString();
                UpdateSummaryLabel();
            }
        }

        void OnDecreaseInfants(object sender, System.EventArgs e)
        {
            int infants = int.Parse(InfantsLabel.Text);
            if (infants > 0)
            {
                infants--;
                InfantsLabel.Text = infants.ToString();
                UpdateSummaryLabel();
            }
        }

        void OnEconomyClassSelected(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedClass = "Эконом";
                SaveSelectedClass();
                UpdateSummaryLabel();
            }
        }

        void OnComfortClassSelected(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedClass = "Комфорт";
                SaveSelectedClass();
                UpdateSummaryLabel();
            }
        }

        void OnBusinessClassSelected(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedClass = "Бизнес";
                SaveSelectedClass();
                UpdateSummaryLabel();
            }
        }

        void OnFirstClassSelected(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedClass = "Первый класс";
                SaveSelectedClass();
                UpdateSummaryLabel();
            }
        }

        async void OnConfirmSelection(object sender, System.EventArgs e)
        {
            // Возвращаем данные на предыдущую страницу
            MessagingCenter.Send(this, "UpdatePassengerClassLabel", SummaryLabel.Text);
            await Navigation.PopModalAsync();
        }

        void SaveSelectedClass()
        {
            Application.Current.Properties["SelectedClass"] = selectedClass;
        }

        void UpdateSelectedClass()
        {
            switch (selectedClass)
            {
                case "Эконом":
                    EconomyClassLabel.IsChecked = true;
                    break;
                case "Комфорт":
                    ComfortClassLabel.IsChecked = true;
                    break;
                case "Бизнес":
                    BusinessClassLabel.IsChecked = true;
                    break;
                case "Первый класс":
                    FirstClassLabel.IsChecked = true;
                    break;
            }
        }

        void UpdateSummaryLabel()
        {
            int totalPassengers = int.Parse(AdultsLabel.Text) + int.Parse(ChildrenLabel.Text) + int.Parse(InfantsLabel.Text);
            SummaryLabel.Text = $"{totalPassengers}, {selectedClass}";
        }
    }
}
 