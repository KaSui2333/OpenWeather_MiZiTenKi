using Newtonsoft.Json;

namespace OpenWeather
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class WeatherDay
    {
        [JsonProperty("nums")]
        public int Nums { get; set; }

        [JsonProperty("cityid")]
        public string Cityid { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("week")]
        public string Week { get; set; }

        [JsonProperty("update_time")]
        public string UpdateTime { get; set; }

        [JsonProperty("wea")]
        public string Wea { get; set; }

        [JsonProperty("wea_img")]
        public string WeaImg { get; set; }

        [JsonProperty("tem")]
        public string Tem { get; set; }

        [JsonProperty("tem_day")]
        public string TemDay { get; set; }

        [JsonProperty("tem_night")]
        public string TemNight { get; set; }

        [JsonProperty("win")]
        public string Win { get; set; }

        [JsonProperty("win_speed")]
        public string WinSpeed { get; set; }

        [JsonProperty("win_meter")]
        public string WinMeter { get; set; }

        [JsonProperty("air")]
        public string Air { get; set; }

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }
    }
}
