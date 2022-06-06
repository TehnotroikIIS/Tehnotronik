using MongoDB.Driver;

namespace Tehnotronik.MongoDB.Factories
{
    public interface IDatabaseFactory
    {
        IMongoDatabase Create();
    }
}
