namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            if (DeviceInfo.Platform == DevicePlatform.Android)
                stack.Background = Brush.MediumPurple;

        }


        private async void OnGetWeatherBtnClicked(object sender, EventArgs e)
        {
            var location = await Geolocation.Default.GetLocationAsync();

            var lon = location.Longitude;
            var lat = location.Latitude;

            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid=adee4d9d26685357054efd2f06359807";

            var myWeather = await WeatherProxy.GetWeatherAsync(url);

            CityLbl.Text = myWeather.name;
            TemperatureLbl.Text = myWeather.main.temp.ToString("F0") + " \u00B0C";
            ConditionsLbl.Text = myWeather.weather[0].description.ToUpper();

            string iconName = myWeather.weather[0].icon;
            string iconUrl = $"https://openweathermap.org/img/wn/{iconName}@2x.png";

            WeatherImg.Source=ImageSource.FromUri(new Uri(iconUrl));
        }
    }

}
