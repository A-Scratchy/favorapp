using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Favor.API.Containers
{

    public class CandidateContainer {

        private readonly HttpClient _httpClient;

        private readonly ILogger<string> _logger;

        private readonly string _endpoint;

        private readonly string _functionKey;

        public CandidateContainer(
            ILogger<string> logger,
            HttpClient httpClient
        ) {
            _endpoint = "https://localhost:7071/api/Candidates/";
            _functionKey = "";
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetByIdAsync(string id)
        {
            var uri = new Uri(_endpoint + "/"+ id + "?code=" + _functionKey);
            _logger.LogDebug(uri.ToString());
            HttpResponseMessage result = null;

            try {
                result = await _httpClient.GetAsync(uri);
            } catch (Exception error) {
                _logger.LogError("error executing call: ", error);
            }
            return result;

        }

    }
}
