using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather
{
    public class Each
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("wea")]
        public string Wea { get; set; }

        [JsonProperty("wea_img")]
        public string WeaImg { get; set; }

        [JsonProperty("tem_day")]
        public string TemDay { get; set; }

        [JsonProperty("tem_night")]
        public string TemNight { get; set; }

        [JsonProperty("win")]
        public string Win { get; set; }

        [JsonProperty("win_speed")]
        public string WinSpeed { get; set; }
    }

    public class WeatherWeek
    {
        [JsonProperty("nums")]
        public int Nums { get; set; }

        [JsonProperty("cityid")]
        public string Cityid { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("update_time")]
        public string UpdateTime { get; set; }

        [JsonProperty("data")]
        public List<Each> Data { get; set; }
    }
}
