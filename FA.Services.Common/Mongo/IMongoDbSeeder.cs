using System.Threading.Tasks;

namespace FA.Common.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}