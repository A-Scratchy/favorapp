using Favor.Functions.Interfaces;
using Favor.Functions.Models;

namespace Favor.Functions
{
    public class BaseFunction<T, T_repository>
        where T : BaseDbEntity
        where T_repository : IRepository<T>, new()
    {

        protected static T_repository _repo = new T_repository();

        public BaseFunction(T_repository repo)
        {
            _repo = repo;
        }

    }
}
