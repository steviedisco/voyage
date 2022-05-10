﻿using VoyageCare.Shared;
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

        public async Task<List<CareHome>?> GetAllCareHomesAsync() =>
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

        public async Task<List<CareHomeStaff>?> GetAllCareHomeStaffAsync(int careHomeID)
        {
            var allStaff = await _httpClient.GetFromJsonAsync<List<CareHomeStaff>>($"{_serverHost}/Staff");

            return allStaff?.Where(x => x.CareHomeID == careHomeID).OrderBy(x => $"{x.Surname}{x.Forename}" ).ToList();
        }

        public async Task<CareHomeStaff?> GetCareHomeStaffAsync(int careHomeStaffID)
        {
            return await _httpClient.GetFromJsonAsync<CareHomeStaff>($"{_serverHost}/Staff/{careHomeStaffID}");
        }

        public async Task<int> SaveCareHomeStaffAsync(CareHomeStaff careHomeStaff)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_serverHost}/Staff", careHomeStaff);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return Convert.ToInt32(content);
            }

            throw new Exception(content);
        }
    }
}