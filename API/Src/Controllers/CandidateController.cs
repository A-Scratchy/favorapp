namespace Favor.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Favor.API.Auth;
    using Favor.API.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Identity.Web.Resource;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<string> _logger;
        private readonly ICandidateContainer _container;

        public CandidateController(ILogger<string> logger, ICandidateContainer candidateContainer)
        {
            _logger = logger;
            _container = candidateContainer;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(Scopes.CandidateRead);

            try
            {
                var guid = new Guid(id);
                var response = await _container.GetByIdAsync(guid);

                return response.IsSuccessStatusCode
                    ? new OkObjectResult(await response.Content.ReadAsStringAsync())
                    : new BadRequestResult();
            }
            catch (FormatException error)
            {
                return new BadRequestObjectResult(error.Message);
            }
        }

        [HttpGet]
        [Authorize(Policy = "ValidId")]
        public async Task<IActionResult> GetFromTokenAsync()
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(Scopes.CandidateRead);

            var id = User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value.ToString();

            _logger.LogDebug(id);

            try
            {
                var guid = new Guid(id);
                var response = await _container.GetByIdAsync(guid);

                return response.IsSuccessStatusCode
                    ? new OkObjectResult(await response.Content.ReadAsStringAsync())
                    : new BadRequestResult();
            }
            catch (FormatException error)
            {
                return new BadRequestObjectResult(error.Message);
            }

        }
    }
}
