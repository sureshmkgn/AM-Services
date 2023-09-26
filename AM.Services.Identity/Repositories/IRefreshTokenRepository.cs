using System;
using System.Threading.Tasks;
using AM.Services.Identity.Domain;

namespace AM.Services.Identity.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}