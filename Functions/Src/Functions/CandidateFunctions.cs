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

    public class CandidateFunctions : BaseFunction<CandidateDto, CandidateRepository>
    {
        public CandidateFunctions(CandidateRepository r) : base(r) { }

        [FunctionName("AddCandidate")]
        public static async Task<IActionResult> AddCandidate(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Candidates")] HttpRequest request,
            ILogger log)
        {
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();

            try
            {
                var candidateToAdd = JsonConvert.DeserializeObject<CandidateDto>(requestBody);
                var result = await _repo.PostAsync(candidateToAdd);
                return new CreatedResult(result.Id.ToString(), result);
            }
            catch (Exception error)
            {
                log.LogError(error.Message);
                return new BadRequestResult();
            }
        }

        [FunctionName("DeleteCandidate")]
        public static async Task<IActionResult> DeleteCandidate(
                [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Candidates/{id}")] HttpRequest request,
                string id, ILogger log)
        {
            try
            {
                var candidateToRemove = await _repo.GetAsync(new Guid(id));
                var result = await _repo.DeleteAsync(candidateToRemove);
                return new NoContentResult();
            }
            catch (Exception error)
            {
                log.LogError(error.Message);
                return new BadRequestResult();
            }
        }

        [FunctionName("GetCandidate")]
        public static async Task<IActionResult> GetCandidateById(
                [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Candidates/{id}")] HttpRequest request,
                string id, ILogger log)
        {
            try
            {
                var candidate = await _repo.GetAsync(new Guid(id));
                return new OkObjectResult(candidate);
            }
            catch (Exception error)
            {
                log.LogError(error.Message);
                return new BadRequestObjectResult(error);
            }
        }

        [FunctionName("GetCandidates")]
        public static async Task<IActionResult> GetCandidates(
                [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Candidates")] HttpRequest request,
                ILogger log)
        {
            try
            {
                var candidates = await _repo.GetAsync();
                return new OkObjectResult(candidates);
            }
            catch (Exception error)
            {
                log.LogError(error.Message);
                return new BadRequestObjectResult(error);
            }
        }

        [FunctionName("UpdateCandidate")]
        public static async Task<IActionResult> UpdateCandidate(
                [HttpTrigger(AuthorizationLevel.Function, "put", Route = "Candidates")] HttpRequest request,
                ILogger log)
        {
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();

            try
            {
                var newCandidateInfo = JsonConvert.DeserializeObject<CandidateDto>(requestBody);
                var result = await _repo.PutAsync(newCandidateInfo);
                return new CreatedResult(result.Id.ToString(), result);
            }
            catch (Exception error)
            {
                log.LogError(error.Message);
                return new BadRequestObjectResult(error.Message);
            }
        }

    }
}
