using Newtonsoft.Json;
using System.Diagnostics;

namespace OpenWeather
{
    public class RestService
    {
        HttpClient _client;
        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<WeatherDay> GetWeatherDay(string query)
        {
            WeatherDay weatherDay = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherDay = JsonConvert.DeserializeObject<WeatherDay>(content);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return weatherDay;
        }

        public async Task<WeatherWeek> GetWeatherWeek(string query)
        {
            WeatherWeek weatherDay = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherDay = JsonConvert.DeserializeObject<WeatherWeek>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return weatherDay;
        }
    }

}
