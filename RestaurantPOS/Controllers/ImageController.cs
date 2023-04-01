using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;


namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public ImageController()
        {
        }

        [HttpGet]
        [Route("{path}")]
        public IActionResult GetImage(string path)
        {
            // Check if the requested file exists on the file system
            var filePath = Path.Combine(path);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Image not found.");
            }

            // Set the content type of the response to the MIME type of the image file
            var contentType = GetContentType(filePath);
            if (contentType == null)
            {
                return StatusCode(500, "Failed to determine content type of the image file.");
            }
            HttpContext.Response.ContentType = contentType;

            // Return the image file as a stream in the response body
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return new FileStreamResult(stream, contentType);
        }

        private string GetContentType(string filePath)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
