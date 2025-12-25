using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using ShamsAlShamoos01.Infrastructure.Services;

namespace ShamsAlShamoos01.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly QrCodeService _qrService;

        public UploadController(IWebHostEnvironment env, QrCodeService qrService)
        {
            _env = env;
            _qrService = qrService;
        }


        [HttpPost("image-to-qr")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file");

            var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsPath);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadsPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            var filePath1 = Path.Combine(uploadsPath, "9c201c6b-4646-4ecb-a712-fd814b7da2a2.jpg");

            // OCR
            string extractedText = _qrService.ImageToBase64(filePath1);

            // Split text
            var parts = _qrService.SplitText(extractedText);

            var qrFiles = new List<string>();
            int index = 1;

            foreach (var part in parts)
            {
                string qrFileName = $"qr_{index++}";
                _qrService.GenerateQrToFile(part, qrFileName);
                qrFiles.Add(qrFileName);
            }

            return Ok(new
            {
                extractedText,
                qrFiles
            });
        }

   
    
    }
}
