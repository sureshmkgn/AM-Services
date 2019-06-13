using System.Threading.Tasks;
using FA.Common.Types;
using FA.Common.Messages;

namespace FA.Common.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}