using Domain;
using MongoDB.Driver;
using Restaurant.Application.Interfaces;

namespace Restaurant.Infrastructure
{
    public class ShopContext : IShopContext
    {
        public ShopContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ShopDb");

            Shops = database.GetCollection<Shop>("shops");
        }

        public IMongoCollection<Shop> Shops { get; }
    }
}