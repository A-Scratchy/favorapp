namespace Favor.API.Containers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Favor.API.Interfaces;
    using System.Net;

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
            _endpoint = "http://localhost:7071/api/Candidates/";
            _functionKey = "";
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id)
        {
            var uri = new Uri(_endpoint + id + "?code=" + _functionKey);

            try
            {
                var response = await _httpClient.GetAsync(uri);
                return response;
            }
            catch (NullReferenceException error)
            {
                _logger.LogError("An error occured after calling GetByIdAsync \n" + error);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadGateway
                };
            }

        }
    }
}
