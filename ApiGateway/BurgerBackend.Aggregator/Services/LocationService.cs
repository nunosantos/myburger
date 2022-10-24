using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _client;

        public LocationService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public LocationModel GetLocationById(string userName)
        {
            return new LocationModel() { AddressLine = "My street", Country = "Denmark" };
        }
    }
}