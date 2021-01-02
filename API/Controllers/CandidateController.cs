namespace Favor.API.Controllers
{
    using Favor.API.Auth;
    using Favor.API.Containers;
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
        private readonly CandidateContainer _container;

        public CandidateController(ILogger<string> logger, ICandidateContainer candidateContainer)
        {
            _logger = logger;
            _container = candidateContainer;
        }

        [HttpGet]
        public string Get()
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(Scopes.UserRead);
            _logger.LogDebug("Get Candidates called");
            var result = CandidateContainer.GetByIdAsync("5ff0653c242a2aafeeac3baf");
            return "you are authenticated :-) Hi " + User.Identity.Name;
        }
    }
}
