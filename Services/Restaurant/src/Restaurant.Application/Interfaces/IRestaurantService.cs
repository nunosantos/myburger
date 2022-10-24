using Restaurant.Application.Model;

namespace Application.Interfaces
{
    public interface IRestaurantService
    {
        void Create(RestaurantDTO restaurantDTO);

        ShopResponseDTO Get(string id);
    }
}