using MongoDB.Driver;

namespace MongoCRUDApi.Models
{
    public class ProductDbContext
    {
        MongoClient client;
        IMongoDatabase database;
        public ProductDbContext()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("StoreDB");
        }
        public IMongoCollection<Product> Products => database.GetCollection<Product>("Products");
    }
}
