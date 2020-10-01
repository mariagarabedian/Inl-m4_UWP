using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedUwpLibraries.Models
{
    public class WeatherList : ObservableCollection<WeatherModel>
    {
        public WeatherList()
        {
            
        }
        public WeatherList(string temperature, string humidity)
        {
            Add(new WeatherModel(temperature, humidity));
        }
    }
}
