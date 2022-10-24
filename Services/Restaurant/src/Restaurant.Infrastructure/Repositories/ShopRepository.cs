using Domain;
using MongoDB.Driver;
using Restaurant.Application.Interfaces;

namespace Restaurant.Infrastructure.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly IShopContext _shopContext;

        public ShopRepository(IShopContext shopContext)
        {
            _shopContext = shopContext ?? throw new ArgumentNullException(nameof(shopContext));
        }

        public async Task CreateShop(Shop shop)
        {
            shop.ShopId = Guid.NewGuid().ToString();
            await _shopContext.Shops.InsertOneAsync(shop);
        }

        public Task<bool> DeleteShop(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Shop> GetShopById(string id)
        {
            FilterDefinition<Shop> filter = Builders<Shop>.Filter.Eq("ShopId", id);

            return _shopContext
                            .Shops
                            .Find(filter)
                            .FirstOrDefault();
        }

        public Task<IEnumerable<Shop>> GetShops()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateShop(Shop product)
        {
            throw new NotImplementedException();
        }
    }
}