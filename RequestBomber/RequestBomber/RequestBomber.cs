using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RequestBomber
{
    class RequestBomber
    {

        public async Task bomb(string path)
        {
            
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            for (int i = 0; i < 100; i++)
            {

                DeviceData devicedata = new DeviceData("device", "data", "time");

                var json = JsonConvert.SerializeObject(devicedata, Formatting.Indented);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://130.225.57.56:51100/DeviceData";

                var response = await client.PostAsync(url, data);
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                Console.WriteLine(i);


            }
            Console.ReadKey();
        }
    }
}
