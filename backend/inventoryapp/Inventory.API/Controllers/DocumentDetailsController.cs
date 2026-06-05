using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentDetailsController : ControllerBase
    {
        private readonly DocumentDetailsService _service;
        private readonly IWebHostEnvironment _env;

        public DocumentDetailsController(
            DocumentDetailsService service,
            IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        [HttpPost("save")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Save(
            [FromForm] int itemId,
            [FromForm] List<string> names,
            [FromForm] List<IFormFile> files)
        {
            var list = new List<DocumentDetails>();

            var count = Math.Min(names?.Count ?? 0, files?.Count ?? 0);

            for (int i = 0; i < count; i++)
            {
                string filePath = null;

                if (files[i] != null)
                {
                    var folder = Path.Combine(_env.WebRootPath, "uploads");

                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    var fileName = Guid.NewGuid() + Path.GetExtension(files[i].FileName);
                    var fullPath = Path.Combine(folder, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await files[i].CopyToAsync(stream);
                    }

                    filePath = "/uploads/" + fileName;
                }

                list.Add(new DocumentDetails
                {
                    ItemId = itemId,
                    Name = names[i],
                    DocumentPath = filePath
                });
            }

            await _service.SaveAsync(itemId, list);

            return Ok(new { message = "Saved successfully" });
        }

        [HttpGet("by-item/{itemId}")]
        public async Task<IActionResult> GetByItem(int itemId)
        {
            var result = await _service.GetByItemIdAsync(itemId);
            return Ok(result);
        }

    }
}