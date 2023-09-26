using System.Threading.Tasks;
using AM.Common.Types;

namespace AM.Common.Handlers
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}