using bloggie.web.repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace bloggie.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var imageURL = await imageRepository.UploadAsync(file);

            if (imageURL == null) {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }

            return Json(new { link = imageURL });
        }
    }
}
