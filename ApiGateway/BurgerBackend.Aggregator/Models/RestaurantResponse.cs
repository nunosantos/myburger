using Shopping.Aggregator.Models;

namespace BurgerBackend.Aggregator.Models
{
    public class RestaurantResponse
    {
        public IEnumerable<ReviewModel> Reviews { get; set; }
        public ShopModel Shop { get; set; }
        public LocationModel Location { get; set; }
    }
}
