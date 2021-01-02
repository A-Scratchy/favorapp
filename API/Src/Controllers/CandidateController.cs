namespace Favor.API.Controllers
{
    using System;
    using System.Net;
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

        [HttpGet]
        public async Task<IActionResult> GetAsync(string id)
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(Scopes.CandidateRead);

            var result = await _container.GetByIdAsync(id);
            try
            {
                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return new OkObjectResult(await result.Content.ReadAsStringAsync());
                    case HttpStatusCode.Unauthorized:
                        return new UnauthorizedResult();
                    case HttpStatusCode.NotFound:
                        return new NotFoundResult();
                }
            }
            catch (NullReferenceException error)
            {
                _logger.LogError("An error occured after calling GetByIdAsync \n" + error);
                return new BadRequestResult();
            }
            return new BadRequestResult();
        }
    }
}
