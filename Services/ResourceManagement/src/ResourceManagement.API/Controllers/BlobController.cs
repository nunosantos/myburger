using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using ResourceManagement.Application.Services;
using ResourceManagement.Domain;

namespace ResourceManagement.API.Controllers
{
    [ApiController]
    public class BlobController : Controller
    {
        [HttpPost("uploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] FileModel fileModel)
        {
            try
            {
                var filename = FileHandler.GenerateFileName(fileModel.File.FileName, fileModel.RestaurantId);
                var fileUrl = "";
                BlobContainerClient container = new BlobContainerClient("Äzure Connection String",
                "Azure Storage Container name");
                try
                {
                    BlobClient blob = container.GetBlobClient(filename);
                    using (Stream stream = fileModel.File.OpenReadStream())
                    {
                        blob.Upload(stream);
                    }
                    fileUrl = blob.Uri.AbsoluteUri;
                }
                catch (Exception ex) { }
                var result = fileUrl;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
    }
}