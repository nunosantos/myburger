using Domain;
using MongoDB.Driver;

namespace Restaurant.Application.Interfaces
{
    public interface IShopContext
    {
        IMongoCollection<Shop> Shops { get; }
    }
}