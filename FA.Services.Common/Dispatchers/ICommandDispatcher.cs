using System.Threading.Tasks;
using FA.Common.Messages;

namespace FA.Common.Dispatchers
{
    public interface ICommandDispatcher
    {
         Task SendAsync<T>(T command) where T : ICommand;
    }
}