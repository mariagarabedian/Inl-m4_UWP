using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SharedUwpLibraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MAD = Microsoft.Azure.Devices;


namespace SharedUwpLibraries.Services
{
    public static class DeviceService
    {
        
        private static HttpClient _client;

        public static async Task<string>SendMessageAsync(DeviceClient deviceClient)
        {

            _client = new HttpClient();

                var response = await _client.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=Kumla,se&APPID=340a1c7e1eb2c2fac4b365398b20c7e8");
            //var data = JsonConvert.DeserializeObject<TemperatureModel.Temperature>(await response.Content.ReadAsStringAsync());
            var data = JsonConvert.DeserializeObject<TemperatureModel.Temperature>(response);
                var weather = new WeatherModel
                {
                    Temperature = data.main.temp.ToString(),
                    Humidity = data.main.humidity.ToString()
                };

                var json = JsonConvert.SerializeObject(weather);

                var payload = new Message(Encoding.UTF8.GetBytes(json));
                await deviceClient.SendEventAsync(payload);

                Console.WriteLine($"Message sent: {json}");

            return json;
            


        }


        public static async Task ReceiveMessageAsync(DeviceClient deviceClient)
        {
            while (true)
            {
                try
                {
                    var payload = await deviceClient.ReceiveAsync();
                    if (payload == null)
                        continue;

                    Console.WriteLine($"Message Received: {Encoding.UTF8.GetString(payload.GetBytes())}");

                    await deviceClient.CompleteAsync(payload);
                }
                catch (Exception ex)
                {
                    break;
                }

            }


        }

        public static async Task SendMessageToDeviceAsync(MAD.ServiceClient serviceClient, string targetDeviceId, string message)
        {
            var payload = new MAD.Message(Encoding.UTF8.GetBytes(message));
            await serviceClient.SendAsync(targetDeviceId, payload);
        }



    }
}
