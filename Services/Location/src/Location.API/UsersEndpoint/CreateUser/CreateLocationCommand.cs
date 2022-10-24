using Common.Logger;
using Infrastructure.Endpoints;
using Location.Application.Interfaces;
using Location.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Location.API.LocationEndpoint.CreateLocation
{
    public class CreateLocationCommand : AsynchronousConnection.WithRequestType<LocationDTO>.WithoutResponseBody
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<LoggingDelegatingHandler> _logger;

        public CreateLocationCommand(ILocationService locationService, ILogger<LoggingDelegatingHandler> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        [HttpPost("restaurant")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override async Task<ActionResult> HandleAsync(LocationDTO request)
        {
            if (request is null)
            {
                _logger.LogWarning("Restaurant creation request is null");
                BadRequest();
            }

            _locationService.Create(request);

            _logger.LogInformation("Restaurant creation request was successful");

            return Created("products", request);
        }
    }
}