namespace Favor.API.Controllers
{
    using Favor.API.Auth;
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

        public CandidateController(ILogger<string> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(Scopes.UserRead);
            _logger.LogDebug("Get Candidates called");
            return "you are authenticated :-) Hi " + User.Identity.Name;
        }
    }
}
