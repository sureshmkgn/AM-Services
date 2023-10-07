using System;
using System.Threading.Tasks;
using AM.Common.Types;

namespace AM.Common.Handlers
{
    public interface IHandler
    {
        IHandler Handle(Func<Task> handle);
        IHandler OnSuccess(Func<Task> onSuccess);
        IHandler OnError(Func<Exception, Task> onError, bool rethrow = false);
        IHandler OnCustomError(Func<AMException, Task> onCustomError, bool rethrow = false);
        IHandler Always(Func<Task> always);
        Task ExecuteAsync();
    }
}