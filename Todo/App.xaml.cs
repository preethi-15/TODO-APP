using Xamarin.Forms;
using Todo.Views;

namespace Todo
{
    public partial class App : Application
    {
        public static double screenwidth { get; set; }
        public static double screenHeight { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProductAddPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"]
            };

            App.Current.Resources["Percentagewidthscreen10"] = Percentagewidthscreen(10);
            App.Current.Resources["Percentageheigthscreen20"] = Percentagewidthscreen(20);
        }
        public static double Percentagewidthscreen(double value)
        {
            var result = (screenwidth * value) / 100;
            return result;

        }

        public static double PercentageHeightscreen(double value)
        {
            var result = (screenHeight * value) / 100;
            return result;

        }

        

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
