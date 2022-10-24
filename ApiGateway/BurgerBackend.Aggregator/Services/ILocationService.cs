using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface ILocationService
    {
        LocationModel GetLocationById(string userName);
    }
}