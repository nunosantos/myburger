using Application.Interfaces;
using Common.Logger;
using Infrastructure.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Model;
using System.Net.Mime;

namespace API.ProductEndpoint.Get
{
    public class GetRestaurantCommand : AsynchronousConnection.WithRequestType<string>.WithResponseType<ShopResponseDTO>
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ILogger<LoggingDelegatingHandler> _logger;

        public GetRestaurantCommand(IRestaurantService restaurantService, ILogger<LoggingDelegatingHandler> logger)
        {
            _restaurantService = restaurantService;
            _logger = logger;
        }

        [HttpGet("restaurant/{restaurantId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override async Task<ActionResult<ShopResponseDTO>> HandleAsync(string restaurantId)
        {
            if (restaurantId == null)
            {
                _logger.LogWarning("Warning Restaurant Id is null or empty {restaurantId}", restaurantId);
                return BadRequest();
            }

            _logger.LogInformation("Started valid restaurant query for product id: {restaurantId}", restaurantId);

            var restaurant = _restaurantService.Get(restaurantId);

            _logger.LogInformation("Restaurant creation request was successful");

            return Ok(restaurant);
        }
    }
}