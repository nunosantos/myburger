using Microsoft.AspNetCore.Mvc;
using BurgerBackend.Aggregator.Models;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services;
using System.Net;

namespace Shopping.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IShopService _shopService;
        private readonly ILocationService _locationService;

        public ShopController(IReviewService reviewService, IShopService shopService, ILocationService locationService)
        {
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
            _shopService = shopService ?? throw new ArgumentNullException(nameof(shopService));
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(ShopModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShopModel>> GetShopping(string userName)
        {
            var restaurantModel = new RestaurantResponse()
            {
                Location = _locationService.GetLocationById(userName),
                Reviews = _reviewService.GetReviewsByUserId(userName),
                Shop = _shopService.GetShop(userName)
            };

            return Ok(restaurantModel);
        }
    }
}