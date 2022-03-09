using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace FileProviderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileProvider _fileProvider;

        public FilesController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        [HttpGet]
        public IActionResult Example()
        {
            var content = _fileProvider.GetDirectoryContents("");

            return Ok(content.Select(x => new { Name = x.Name, Path = x.PhysicalPath }).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken token)

        {
            if (photo != null && photo.Length > 0)
            {
                var wwwroot = _fileProvider.GetDirectoryContents("wwwroot");

                var photosDirectory = wwwroot.First(x => x.Name == "photos");

                var path = Path.Combine(photosDirectory.PhysicalPath, photo.FileName);

                using var stream = new FileStream(path, FileMode.Create);

                await photo.CopyToAsync(stream, token);

                return Ok();
            }
            return BadRequest();
        }
    }
}