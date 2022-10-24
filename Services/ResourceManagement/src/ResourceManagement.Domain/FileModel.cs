using Microsoft.AspNetCore.Http;

namespace ResourceManagement.Domain
{
    public class FileModel
    {
        public IFormFile File { get; set; }
        public string RestaurantId { get; set; }
    }
}