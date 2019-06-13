using System.Threading.Tasks;
using FA.Common.Types;

namespace FA.Common.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}