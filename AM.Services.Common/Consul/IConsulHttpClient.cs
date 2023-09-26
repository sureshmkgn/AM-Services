using System.Threading.Tasks;

namespace AM.Common.Consul
{
    public interface IConsulHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}

