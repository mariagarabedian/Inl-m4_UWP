using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace SharedUwpLibraries.Models
{
    public class WeatherModel// : ObservableCollection<TemperatureModel>
    {
        public string Temperature { get; set; }
        public string Humidity { get; set; }

        public WeatherModel()
        {
           
        }
        public WeatherModel(string temperature, string humidity)
        {
            Temperature = temperature;
            Humidity = humidity;
        }
    }

    
}
