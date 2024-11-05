using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace APISocialAPP.Models
{
    public class CsrfService
    {
        private readonly HttpClient _httpClient;
        private string _csrfToken;

        private const string CsrfUri = "http://127.0.0.1:8000/api/csrf/";

        public CsrfService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCsrfTokenAsync()
        {
            if (string.IsNullOrEmpty(_csrfToken))
            {
                // Haetaan CSRF-token vain, jos sitä ei vielä ole
                var response = await _httpClient.GetAsync(CsrfUri);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var csrfData = JsonConvert.DeserializeObject<CsrfTokenResponse>(json);
                    _csrfToken = csrfData?.CsrfToken; 

                    
                }
            }

            return _csrfToken;
        }

        private class CsrfTokenResponse
        {
            [JsonProperty("csrfToken")] // Vastattava JSON avainta
            public string CsrfToken { get; set; }
        }
    }
}
