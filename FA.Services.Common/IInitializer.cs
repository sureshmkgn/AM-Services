using System.Threading.Tasks;

namespace FA.Common
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}