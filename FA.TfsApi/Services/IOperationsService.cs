using System;
using System.Threading.Tasks;
using RestEase;
using FA.Api.Models.Operations;

namespace FA.Api.Services
{
    public interface IOperationsService
    {
        [AllowAnyStatusCode]
        [Get("operations/{id}")]
        Task<Operation> GetAsync([Path] Guid id);          
    }
}