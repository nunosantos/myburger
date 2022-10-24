using Domain;

namespace Restaurant.Application.Interfaces
{
    public interface IShopRepository
    {
        Task<IEnumerable<Shop>> GetShops();

        Task<Shop> GetShopById(string id);

        Task CreateShop(Shop product);

        Task<bool> UpdateShop(Shop product);

        Task<bool> DeleteShop(string id);
    }
}