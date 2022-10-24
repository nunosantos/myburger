using Application.Interfaces;
using AutoMapper;
using Common.Logger;
using Domain;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Model;

namespace Application.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IShopRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<LoggingDelegatingHandler> _logger;

        public RestaurantService(IShopRepository repository, IMapper mapper, ILogger<LoggingDelegatingHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public void Create(RestaurantDTO restaurantDTO)
        {
            _logger.LogInformation("Restaurant creation started {restaurantName}", restaurantDTO.Name);
            var shop = _mapper.Map<Shop>(restaurantDTO);
            _repository.CreateShop(shop);
        }

        public ShopResponseDTO Get(string id)
        {
            _logger.LogInformation("Fetching restaurant {id} started", id);
            var shop = _repository.GetShopById(id);
            return new ShopResponseDTO(shop.Result);
        }
    }
}