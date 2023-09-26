using System.Threading.Tasks;
using AM.Common.Messages;

namespace AM.Common.Dispatchers
{
    public interface ICommandDispatcher
    {
         Task SendAsync<T>(T command) where T : ICommand;
    }
}