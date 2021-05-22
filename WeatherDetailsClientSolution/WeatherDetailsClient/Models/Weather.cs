using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherDetailsClient.Models
{
    public class Weather
    {
        public DateTime date { get; set; }
        public string city { get; set; }
        public float highTemp { get; set; }
        public float lowTemp { get; set; }
        public string forcast { get; set; }
    }
}
