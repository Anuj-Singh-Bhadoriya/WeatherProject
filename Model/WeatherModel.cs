using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppApi.Model
{
    public class WeatherModel
    {
        public String? City { get; set; }
        public double? Celsius_Temp { get; set; }
        public int? Humidity { get; set; }
        public String? Condition { get; set; }

    }
}
