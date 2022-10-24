using Application.Interfaces;
using Common.Logger;
using Infrastructure.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Model;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace API.RestaurantEndpoint.Create
{
    public class CreateRestaurantCommand : AsynchronousConnection.WithRequestType<RestaurantDTO>.WithoutResponseBody
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ILogger<LoggingDelegatingHandler> _logger;

        public CreateRestaurantCommand(IRestaurantService restaurantService, ILogger<LoggingDelegatingHandler> logger)
        {
            _restaurantService = restaurantService;
            _logger = logger;
        }

        [HttpPost("restaurant")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override async Task<ActionResult> HandleAsync(RestaurantDTO request)
        {
            if (request is null)
            {
                _logger.LogWarning("Restaurant creation request is null");
                BadRequest();
            }

            _restaurantService.Create(request);

            _logger.LogInformation("Restaurant creation request was successful");

            return Created("products", request);
        }
    }
}