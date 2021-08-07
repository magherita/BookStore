using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    [Route("api/file")]
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _iwebHostEnvironment;

        public FileController(IWebHostEnvironment iwebHostEnvironment)
        {
            _iwebHostEnvironment = iwebHostEnvironment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                var path = Path.Combine(_iwebHostEnvironment.WebRootPath, "images", file.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
                return  Ok((new { length = file.Length, name = file.FileName }));
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}