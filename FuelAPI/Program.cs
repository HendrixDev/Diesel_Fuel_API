using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FuelAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string seriesID = "PET.EMD_EPD2D_PTE_NUS_DPG.W";
            const string ApiKey = "2864c8ba67b3ea00645e70c7288e5854";
            string currentDiesel;
            string year;
            string month;
            string day;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.eia.gov/");
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"series/?api_key={ApiKey}&series_id={seriesID}").Result;

                RootObject data = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);

                List<DataObject> listData = new List<DataObject>();

                //Two foreach; acessing lists within a list.
                foreach (var item in data.series)
                {
                    foreach (var item2 in item.data)
                    {
                        DataObject dataObject = new DataObject();
                        dataObject.date = item2[0].ToString();
                        dataObject.price = Convert.ToDouble(item2[1]);
                        listData.Add(dataObject);

                    }
                }

                year = listData[0].date.Substring(0, 4);
                month = listData[0].date.Substring(4, 2);
                day = listData[0].date.Substring(6, 2);

                currentDiesel = $"As of {month}/{day}/{year}: ${listData[0].price} per gallon";

                Console.WriteLine(currentDiesel);

            }
        }
    }
}
