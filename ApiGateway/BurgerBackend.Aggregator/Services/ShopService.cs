using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class ShopService : IShopService
    {
        private readonly HttpClient _client;

        public ShopService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public ShopModel GetShop(string restaurantId)
        {
            return new ShopModel() { Name = "My restaurant" };
        }
    }
}