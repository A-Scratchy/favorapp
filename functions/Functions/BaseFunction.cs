using System;
using Microsoft.Extensions.Logging;

namespace Favor.Functions
{
    public class BaseFunction<T_document, T_repository>
        where T_document : new()
        where T_repository : new()
    {
        protected static ILogger<T_document> _logger;

        protected static T_repository _repo = new T_repository();

        public BaseFunction()
        {

        }

        public BaseFunction(T_repository repo, ILogger<T_document> logger)
        {
            _repo = repo;
            _logger = logger;
        }

    }
}
