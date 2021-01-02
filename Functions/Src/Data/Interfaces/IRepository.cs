using System.Threading.Tasks;
using Favor.Functions.Models;
using MongoDB.Bson;

namespace Favor.Functions.Interfaces
{

    public interface IRepository<T> where T : BaseDbEntity
    {
        Task<T> GetByIdAsync(ObjectId id);

        Task<ObjectId> AddAsync(T document);

        Task<bool> EditAsync(T document);

        Task<bool> DeleteAsync(T document);
    }

}
