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
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;

    public class CandidateFunctions : BaseFunction<CandidateDbModel, CandidateRepository>
    {
        public CandidateFunctions(CandidateRepository r) : base(r) { }

        [FunctionName("AddCandidate")]
        public static async Task<IActionResult> AddCandidate(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Candidate")] HttpRequest request,
            ILogger log)
        {
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            try
            {
                var candidateToAdd = JsonConvert.DeserializeObject<CandidateDbModel>(requestBody);
                var id = await _repo.AddAsync(candidateToAdd);
                return new OkObjectResult(id.ToString());
            }
            catch (Exception error)
            {
                log.LogError(error.Message);
                return new BadRequestObjectResult(false);
            }
        }

        [FunctionName("GetCandidate")]
        public static async Task<IActionResult> GetCandidateById(
                [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Candidate/{id}")] HttpRequest request,
                string id, ILogger log)
        {
            try
            {
                var candidate = await _repo.GetByIdAsync(new ObjectId(id));
                return new OkObjectResult(candidate);
            }
            catch (Exception error)
            {
                log.LogError(error.Message);
                return new BadRequestObjectResult(error);
            }
        }

        [FunctionName("DeleteCandidate")]
        public static async Task<IActionResult> DeleteCandidate(
                [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Candidate/{id}")] HttpRequest request,
                string id, ILogger log)
        {
            try
            {
                var candidateToRemove = await _repo.GetByIdAsync(new ObjectId(id));
                var result = await _repo.DeleteAsync(candidateToRemove);
                return new OkObjectResult(result);
            }
            catch (Exception error)
            {
                log.LogError(error.Message);
                return new BadRequestObjectResult(false);
            }
        }

        [FunctionName("UpdateCandidate")]
        public static async Task<IActionResult> UpdateCandidate(
                [HttpTrigger(AuthorizationLevel.Function, "patch", Route = "Candidate/{id}")] HttpRequest request,
                string id, ILogger log)
        {
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            try
            {
                var newCandidateInfo = BsonSerializer.Deserialize<CandidateDbModel>(requestBody);
                newCandidateInfo.Id = new ObjectId(id);
                var result = await _repo.EditAsync(newCandidateInfo);
                return new OkObjectResult(true);
            }
            catch (Exception error)
            {
                log.LogError(error.Message);
                return new BadRequestObjectResult(error.Message);
            }
        }

    }
}
