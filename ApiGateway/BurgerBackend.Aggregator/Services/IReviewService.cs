using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface IReviewService
    {

        IEnumerable<ReviewModel> GetReviewsByUserId(string id);
    }
}