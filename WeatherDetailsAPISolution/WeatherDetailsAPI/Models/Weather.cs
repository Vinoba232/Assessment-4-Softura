using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherDetailsAPI.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }
        [Key]
        public string City { get; set; }
        public float HighTemp { get; set; }
        public float LowTemp { get; set; }
        public string Forcast { get; set; }

    }
}
