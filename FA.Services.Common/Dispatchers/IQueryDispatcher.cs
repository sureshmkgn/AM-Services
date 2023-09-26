using System.Threading.Tasks;
using AM.Common.Types;

namespace AM.Common.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}