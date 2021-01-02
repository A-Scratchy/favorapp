using System;
using System.Threading.Tasks;
using Favor.Functions.Models;

namespace Favor.Functions.Interfaces
{

    public interface IRepository<T> where T : BaseDbEntity
    {
        Task<T> GetByIdAsync(Guid id);

        Task<bool> AddAsync(T document);

        Task<bool> EditAsync(T document);

        Task<bool> DeleteAsync(T document);
    }

}
