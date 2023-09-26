using System.Threading.Tasks;

namespace AM.Common.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}