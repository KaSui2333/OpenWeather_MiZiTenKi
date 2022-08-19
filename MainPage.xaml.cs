using System.Diagnostics;

namespace OpenWeather;

public partial class MainPage : ContentPage
{
	RestService _restService;
	public MainPage()
	{
        InitializeComponent();
        _restService = new RestService();
        Routing.RegisterRoute("Donate", typeof(Donate));
        Load("");
    }
    async void Load(string city)
    {
        WeatherDay weatherDay = await _restService.GetWeatherDay(GenerateRequestURLDay(Constants.OpenWeatherMapEndpoint, city));
        if (weatherDay != null) 
        {
            _cityChoose.BindingContext = weatherDay;
            _nowWeatherData.BindingContext = weatherDay;
            _nowOtherData.BindingContext = weatherDay;
        }
        WeatherWeek weatherWeek = await _restService.GetWeatherWeek(GenerateRequestURLWeek(Constants.OpenWeatherMapEndpoint, city));
        if (weatherWeek != null)
        {
            _5DayData.BindingContext = weatherWeek;
        }
    }

    async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        string city = picker.Items[selectedIndex];
        if (selectedIndex != -1)
        {
            WeatherDay weatherDay = await _restService.GetWeatherDay(GenerateRequestURLDay(Constants.OpenWeatherMapEndpoint, city));
            if (weatherDay != null)
            {
                _cityChoose.BindingContext = weatherDay;
                _nowWeatherData.BindingContext = weatherDay;
                _nowOtherData.BindingContext = weatherDay;
            }
            WeatherWeek weatherWeek = await _restService.GetWeatherWeek(GenerateRequestURLWeek(Constants.OpenWeatherMapEndpoint, city));
            if (weatherWeek != null)
            {
                _5DayData.BindingContext = weatherWeek;
            }
        }
    }

    string GenerateRequestURLDay(string endPoint, string city)
    {
        string requestUri = endPoint;
        requestUri += $"day?appid={Constants.OpenWeatherMapAPIID}";
        requestUri += $"&appsecret={Constants.OpenWeatherMapAPIPassword}";
        requestUri += $"&city={city}";
        requestUri += "&unescape=1";
        return requestUri;
    }

    string GenerateRequestURLWeek(string endPoint, string city)
    {
        string requestUri = endPoint;
        requestUri += $"week?appid={Constants.OpenWeatherMapAPIID}";
        requestUri += $"&appsecret={Constants.OpenWeatherMapAPIPassword}";
        requestUri += $"&city={city}";
        requestUri += "&unescape=1";
        return requestUri;
    }

    async void OnDonateCLC(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Donate");
    }

    async void OnHelpCLC(object sender, EventArgs e)
    {
        string city = await DisplayPromptAsync("没有你的城市？","不如自己键入（可精确到区哦）：\n格式为：湖州 or 吴兴");
        if (city != null)
        {
            Load(city);
        }
    }

    async void OnAboutCLC(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("关于", "本项目完全开源，开源地址为：\nhttps://github.com/KaSui2333/OpenWeather_MiZiTenKi\nAPI From yiketianqi.com\nProduce By KaSui", "OK","GoTo");
        if (!answer)
        {
            try
            {
                Uri uri = new Uri("https://github.com/KaSui2333/OpenWeather_MiZiTenKi");
                await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }

}

