namespace Favor.Functions
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Favor.Functions.Models;
    using Favor.Functions.Repositories;

    public class CandidateFunctions : BaseFunction<CandidateDbModel, CandidateRepository>
    {
        public CandidateFunctions(CandidateRepository r) : base(r) { }

        [FunctionName("AddCandidate")]
        public static async Task<IActionResult> AddCandidate(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Candidate/Add")] HttpRequest request,
            ILogger log)
        {
            var result = false;
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            try
            {
                var candidateToAdd = JsonConvert.DeserializeObject<CandidateDbModel>(requestBody);
                log.LogDebug("Adding candidate with name: " + candidateToAdd.FirstName);
                await _repo.AddAsync(candidateToAdd);
                result = true;
            }
            catch (Exception error)
            {
                log.LogError(error.Message);
            }

            return new OkObjectResult(result);
        }
    }
}
