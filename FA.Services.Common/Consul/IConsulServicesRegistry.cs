using System.Threading.Tasks;
using Consul;

namespace FA.Common.Consul
{
    public interface IConsulServicesRegistry
    {
        Task<AgentService> GetAsync(string name);
    }
}