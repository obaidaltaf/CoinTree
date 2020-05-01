using CTWebAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CTWebAPI.Controllers
{
    public class Helper : IHelper
    {
        HttpClient client;
        IConfiguration configuration { get; }
        public Helper(HttpClient _client, IConfiguration _configuration)
        {
            client = _client;
            configuration = _configuration;
        }

        public async Task<List<CryptoRates>> runAPI()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            //var webProxy = new WebProxy(new Uri(configuration["ProxyUri"]), BypassOnLocal: false);
            //var proxyHttpClientHandler = new HttpClientHandler
            //{
            //    Proxy = webProxy,
            //    UseProxy = true,
            //};

            //client = new HttpClient(proxyHttpClientHandler);
            client.BaseAddress = new Uri(configuration["CrytoRatesAPIBaseURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var url = client.BaseAddress + configuration["CrytoRatesAPI"];
            response = await client.GetAsync(url);
            List<CryptoRates> cryptoRatesList = new List<CryptoRates>();
            if (response.IsSuccessStatusCode)
            {
                cryptoRatesList = await JsonSerializer.DeserializeAsync<List<CryptoRates>>(await response.Content.ReadAsStreamAsync());
            }
            return cryptoRatesList;
        }
    }
}
