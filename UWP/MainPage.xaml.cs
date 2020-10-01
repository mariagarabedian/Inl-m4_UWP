using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SharedUwpLibraries.Models;
using SharedUwpLibraries.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP
{
   
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static readonly string _conn = "HostName=ec-win20-min-iothub.azure-devices.net;DeviceId=consoleapp;SharedAccessKey=FFKKKzILXO5ti7goQ1Jxzg1eaAuDpszzd/pO5hawu78=";
        private static readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(_conn, TransportType.Mqtt);


        public MainPage()
        {
            this.InitializeComponent();
        }

        public WeatherList weatherList = new WeatherList();

        private async void btnGetTemperature_Click(object sender, RoutedEventArgs e)
        {
            var result = await DeviceService.SendMessageAsync(deviceClient);

            

            try
            {
                weatherList.Add(new WeatherModel(result,""));
                lvWeatherList.ItemsSource = weatherList;
            }
            catch { }
        }


    }
}
