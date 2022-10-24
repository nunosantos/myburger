using Domain;

namespace Restaurant.Application.Model
{
    public class ShopResponseDTO
    {
        public ShopResponseDTO(Shop shop)
        {
            Name = shop.Name;
            Menu = shop.Menu;
        }

        public string? Name { get; set; }
        public Menu Menu { get; set; }
    }
}