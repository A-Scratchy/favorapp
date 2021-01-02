
namespace Favor.API.Containers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Favor.API.Interfaces;
    using System.Security.Cryptography.X509Certificates;

    public class CandidateContainer : ICandidateContainer
    {

        private readonly HttpClient _httpClient;

        private readonly ILogger<string> _logger;

        private readonly string _endpoint;

        private readonly string _functionKey;

        public CandidateContainer(
            ILogger<string> logger,
            HttpClient httpClient
        )
        {
            _endpoint = "http://localhost:7071/api/Candidate/";
            _functionKey = "";
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetByIdAsync(string id)
        {
            var uri = new Uri(_endpoint + id + "?code=" + _functionKey);
            _logger.LogDebug(uri.ToString());
            _logger.LogDebug(_httpClient.ToString());

            try
            {
                var response = await _httpClient.GetAsync(uri);
                _logger.LogDebug("responded with status: " + response.StatusCode.ToString());
                return response;
            }
            catch (HttpRequestException error)
            {
                _logger.LogError("error executing call: " + error.Message);
                return null;
            }

        }

    }
}
