using System.Threading.Tasks;

namespace AM.Common
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}