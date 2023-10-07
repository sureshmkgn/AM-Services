using System;
using System.Threading.Tasks;
using RestEase;
using AM.Services.Projects.Operations;

namespace AM.Services.Projects.Services
{
    public interface IOperationsService
    {
        [AllowAnyStatusCode]
        [Get("operations/{id}")]
        Task<Operation> GetAsync([Path] Guid id);          
    }
}