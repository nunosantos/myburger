using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class ReviewService : IReviewService
    {
        private readonly HttpClient _client;

        public ReviewService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public IEnumerable<ReviewModel> GetReviewsByUserId(string id)
        {
            yield return new ReviewModel() { Taste = "Amazing burger" };
            yield return new ReviewModel() { Taste = "Could be better " };
            yield return new ReviewModel() { Taste = "Not sure if I am coming back anymore" };
            yield return new ReviewModel() { Taste = "The service is good" };
        }
    }
}