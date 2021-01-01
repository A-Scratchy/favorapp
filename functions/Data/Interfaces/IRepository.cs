using System.Threading.Tasks;
using Favor.Functions.Models;
using MongoDB.Bson;

namespace Favor.Functions.Interfaces
{

    public interface IRepository<T> where T : BaseDbEntity
    {
        T GetById(ObjectId id);

        Task<T> AddAsync(T document);

        Task<bool> EditAsync(T document);

        Task<T> DeleteAsync(T document);
    }

}
