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

        //public async Task<SearchResults?> GetMovies(string query) =>
        //    await _httpClient.GetFromJsonAsync<SearchResults>($"{_serverHost}/api/Movie/{query}");
    }
}