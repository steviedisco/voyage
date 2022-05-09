using VoyageCare.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace VoyageCare.GUI
{
    public class VoyageCareClient
    {
        private readonly HttpClient _httpClient;
        private readonly string     _serverHost;

        public VoyageCareClient(IConfiguration configuration,
                                HttpClient     httpClient)
        {
            this._httpClient = httpClient;
            this._serverHost = configuration.GetValue<string>("ApiUrls:VoyageCare.Server");
        }

        public async Task<List<CareHome>?> GetCareHomesAsync() =>
            await _httpClient.GetFromJsonAsync<List<CareHome>>($"{_serverHost}/CareHome");

        public async Task<int> SaveCareHomeAsync(CareHome careHome)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_serverHost}/CareHome", careHome);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return Convert.ToInt32(content);
            }

            throw new Exception(content);
        }
    }
}