namespace Favor.API.Interfaces
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    public interface IContainer
    {
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
    }
}
