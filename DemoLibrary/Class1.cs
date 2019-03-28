using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public static class FuelData
    {
        // Running this code requires replacing "YOUR REQUESTED KEY" with a key
        // obtained from U.S. Energy Information Administration.

        private const string ApiKey = "2864c8ba67b3ea00645e70c7288e5854";

        public static async Task<string> GetDemandRaw(string seriesID)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://api.eia.gov/series/?api_key={ApiKey}&series_id={seriesID}");
                return await response.Content.ReadAsStringAsync();
            }
        }

    }
}
