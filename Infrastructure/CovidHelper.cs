using CovidApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace CovidApp.Infrastructure
{
    class CovidHelper : ICovidHelper
    {
        private const string apiUrl = "https://api.covid19api.com";

        public List<Countries> getCountries()
        {
            List<Countries> countryList = new List<Countries>();
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = client.GetAsync(apiUrl + "/countries").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                String response = responseMessage.Content.ReadAsStringAsync().Result;
                var countryArray = JsonConvert.DeserializeObject<List<Countries>>(response);
                foreach (var country in countryArray)
                    countryList.Add(country);
            }
            client.Dispose();
            return countryList;
        }

        public List<CountryInfo> getCountryInfoList(string slug)
        {
            List<CountryInfo> countryInfoList = new List<CountryInfo>();
            HttpClient client = new HttpClient();
            string url = apiUrl + "/total/dayone/country/" + slug;
            HttpResponseMessage responseMessage = client.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                String response = responseMessage.Content.ReadAsStringAsync().Result;
                try
                {
                    countryInfoList = JsonConvert.DeserializeObject<List<CountryInfo>>(response);
                }
                catch (Exception) { }
            }
            client.Dispose();
            return countryInfoList;
        }
    }
}
