using System.Net.Http;
using System.Threading.Tasks;

namespace Favor.API.Interfaces
{
    public interface IContainer
    {
        Task<HttpResponseMessage> GetByIdAsync(string id);
    }
}
