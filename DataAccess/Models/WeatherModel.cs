using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class WeatherModel
    {
        public double Temp { get; set; }
        public double TempFeel { get; set; }
        public string WeatherName { get; set; }
        public double Wind { get; set; }
        public string Icon { get; set; }
    }
}
