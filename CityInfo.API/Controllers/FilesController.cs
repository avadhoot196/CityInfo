﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
            ?? throw new System.ArgumentException(nameof(fileExtensionContentTypeProvider));
        }
        [HttpGet("{filedId}")]
        public ActionResult GetFile(string filedId)
        {
            //look up the actual file, depending on the filedId...
            //demo code
            var pathToFile = "getting-started-with-rest-slides.pdf";

            //check whether the file exists
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }
            //use for pdf file format
            if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
        [HttpPost]
        public async Task<ActionResult> CreateFile(IFormFile file)
        {
            if (file.Length == 0 || file.Length > 20971520 || file.ContentType != "application/pdf")
            {
                return BadRequest("No File or an invalid one has inputted.");
            }
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"uploaded_file_{Guid.NewGuid()}.pdf");

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok("Your file has been uploaded successfully.");
        }
    }
}
