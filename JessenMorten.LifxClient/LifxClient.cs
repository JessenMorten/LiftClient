using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using JessenMorten.LifxClient.Models;

namespace JessenMorten.LifxClient
{
    /// <summary>
    /// <see cref="LifxClient"/> provides a simple interface to communicate with version 1 of the LIFX API.
    /// </summary>
    public class LifxClient : ILifxClient
    {
        private const string _baseUrl = "https://api.lifx.com/v1/";

        private readonly string _apiKey;

        public LifxClient(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        /// <summary>
        /// Get all <see cref="LifxBulb"/>s.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LifxBulb>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<LifxBulb>>("lights/all");
        }

        /// <summary>
        /// Toggle <see cref="LifxBulb"/> (on/off).
        /// </summary>
        public async Task TogglePowerAsync(LifxBulb bulb)
        {
            await PostAsync($"lights/{bulb.Id}/toggle");
        }

        /// <summary>
        /// Turn on <see cref="LifxBulb"/>.
        /// </summary>
        public async Task TurnOnAsync(LifxBulb bulb)
        {
            var data = new { states = new[] { new { selector = $"id:{bulb.Id}", power = "on" } } };
            await PutAsync("lights/states", data);
        }

        /// <summary>
        /// Turn off <see cref="LifxBulb"/>.
        /// </summary>
        public async Task TurnOffAsync(LifxBulb bulb)
        {
            var data = new { states = new[] { new { selector = $"id:{bulb.Id}", power = "off" } } };
            await PutAsync("lights/states", data);
        }

        /// <summary>
        /// Set color on <see cref="LifxBulb"/>, see examples below:
        /// 
        /// <list type="bullet">
        ///     <item>"#ff0000" – Deep red, maximum brightness</item>
        ///     <item>"hue:120 saturation:1.0 brightness:0.5" – Deep green, 50% brightness</item>
        ///     <item>"kelvin:2700 brightness: 0.5" – Warm white (2700 K), 50% brightness</item>
        ///     <item>"rgb:0,255,255" – Cyan, 100% brightness</item>
        ///     <item>"kelvin:5000" – Set kelvin to cool white (5000 K) and saturation to 0 without affecting other components</item>
        ///     <item>"kelvin:2700 saturation:1" – Set kelvin to warm (2700 K) and saturation to 1</item>
        ///     <item>"brightness:0.75" – Set brightness to 75% without affecting other components</item>
        ///     <item>"saturation:0.25" – Set saturation to 25% without affecting other components</item>
        ///     <item>"red" – Sets color to red but doesn't affect brightness</item>
        /// </list>
        /// 
        /// </summary>
        public async Task SetColorAsync(LifxBulb bulb, string color)
        {
            var data = new { States = new[] { new { selector = $"id:{bulb.Id}", color } } };
            await PutAsync("lights/states", data);
        }

        /// <summary>
        /// Start pulse effect on <see cref="LifxBulb"/>.
        /// </summary>
        public async Task PulseAsync(LifxBulb bulb, string color, string fromColor = null, int cycles = 3, double period = 1.0)
        {
            var data = new { color, from_color = fromColor, cycles, period };
            await PostAsync($"lights/{bulb.Id}/effects/pulse", data);
        }

        /// <summary>
        /// Start breathe effect on <see cref="LifxBulb"/>.
        /// </summary>
        public async Task BreatheAsync(LifxBulb bulb, string color, string fromColor = null, int cycles = 3, double period = 1.0)
        {
            var data = new { color, from_color = fromColor, cycles, period };
            await PostAsync($"lights/{bulb.Id}/effects/breathe", data);
        }

        /// <summary>
        /// Stop effect on <see cref="LifxBulb"/>.
        /// </summary>
        public async Task StopEffectsAsync(LifxBulb bulb)
        {
            await PostAsync($"lights/{bulb.Id}/effects/off");
        }

        /// <summary>
        /// Set state of <see cref="LifxBulb"/>.
        /// </summary>
        public async Task SetStateAsync(LifxBulb bulb, string color = null, bool on = true, double brightness = 1.0, double duration = 1.0)
        {
            var data = new { States = new[] { new { Selector = $"id:{bulb.Id}", power = on ? "on" : "off", color, brightness, duration } } };
            await PutAsync("lights/states", data);
        }

        private async Task<T> GetAsync<T>(string relativeUrl)
        {
            using HttpClient httpClient = CreateHttpClient();
            return await httpClient.GetFromJsonAsync<T>(_baseUrl + relativeUrl);
        }

        private async Task PutAsync<T>(string relativeUrl, T payload)
        {
            using HttpClient httpClient = CreateHttpClient();
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(_baseUrl + relativeUrl, payload);
            response.EnsureSuccessStatusCode();
        }

        private async Task PostAsync<T>(string relativeUrl, T payload)
        {
            using HttpClient httpClient = CreateHttpClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(_baseUrl + relativeUrl, payload);
            response.EnsureSuccessStatusCode();
        }

        private async Task PostAsync(string relativeUrl)
        {
            using HttpClient httpClient = CreateHttpClient();
            HttpResponseMessage response = await httpClient.PostAsync(_baseUrl + relativeUrl, null);
            response.EnsureSuccessStatusCode();
        }

        private HttpClient CreateHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            return httpClient;
        }
    }
}
