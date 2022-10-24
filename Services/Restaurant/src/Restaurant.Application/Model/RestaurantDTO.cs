using Domain;

namespace Restaurant.Application.Model
{
    public class RestaurantDTO
    {
        public string? Name { get; set; }
        public MenuDTO Menu { get; set; }
        public ContactInformation? ContactInformation { get; set; }
    }
}