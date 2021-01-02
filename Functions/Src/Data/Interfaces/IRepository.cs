using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Favor.Functions.Models;

namespace Favor.Functions.Interfaces
{

    public interface IRepository<T> where T : BaseDbEntity
    {
        Task<ICollection<T>> GetAsync();

        Task<T> GetAsync(Guid id);

        Task<T> PostAsync(T document);

        Task<T> PutAsync(T document);

        Task<bool> DeleteAsync(T document);
    }

}
