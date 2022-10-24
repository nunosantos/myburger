using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface IShopService
    {
        ShopModel GetShop(string id);
    }
}