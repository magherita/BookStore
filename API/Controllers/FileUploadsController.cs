using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace API.Controllers
{
    public class FileUploadsController : Controller
    {
        public readonly IHostingEnvironment _hostingEnvironment;
        public FileUploadsController(IHostingEnvironment _hostingEnvironment)
        {
            _hostingEnvironment = _hostingEnvironment;
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return Content(("file not selected"));
            long size = files.Sum((f => f.Length));
            var filePaths = new List<String>();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // Full path to the file in temp location

                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "userimages");
                    filePaths.Add(filePath);
                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);
                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            return Ok(new
            {
                count = files.Count, size, filePaths
            });

        }
        
    }
}