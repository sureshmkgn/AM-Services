using System;
using System.Threading.Tasks;
using RestEase;
using AM.Api.Domain.Operations;

namespace AM.Api.Services
{
    public interface IOperationsService
    {
        [AllowAnyStatusCode]
        [Get("operations/{id}")]
        Task<Operation> GetAsync([Path] Guid id);          
    }
}