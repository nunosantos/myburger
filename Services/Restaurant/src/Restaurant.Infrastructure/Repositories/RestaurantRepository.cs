using Domain;
using Restaurant.Application.Interfaces;

namespace Restaurant.Infrastructure.Repositories
{
    public class RestaurantRepository : IShopRepository
    {
        private readonly IShopContext _shopContext;

        public RestaurantRepository(IShopContext shopContext)
        {
            _shopContext = shopContext ?? throw new ArgumentNullException(nameof(shopContext));
        }

        public async Task CreateShop(Shop shop)
        {
            await _shopContext.Shops.InsertOneAsync(shop);
        }

        public Task<bool> DeleteShop(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Shop> GetShopById(string id)
        {
            throw new NotImplementedException();
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