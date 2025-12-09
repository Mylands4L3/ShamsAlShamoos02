using Microsoft.AspNetCore.Mvc;
using ShamsAlShamoos01.Infrastructure.Services;
using System.Data.Common;

namespace ShamsAlShamoos01.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QrController : ControllerBase
    {
        private readonly QrCodeService _qr;
        private readonly QrBatchService _qrBatch;

        public QrController(QrCodeService qr, QrBatchService qrBatch)
        {
            _qr = qr; 
            _qrBatch = qrBatch;

        }
        [HttpGet("GetAllFiles")]
        public IActionResult GetAllFiles()
        {
            // مسیر واقعی پوشه QRها
            string qrFilesPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "QrFiles"));

            if (!System.IO.Directory.Exists(qrFilesPath))
                return Ok(new List<string>()); // اگر پوشه وجود ندارد، لیست خالی

            var files = System.IO.Directory.GetFiles(qrFilesPath, "*.png")
                                           .Select(f => Path.GetFileNameWithoutExtension(f))
                                           .ToList();

            return Ok(files);
        }
        [HttpGet("Generate")]
        public IActionResult Generate([FromQuery] string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return BadRequest("Text cannot be empty");
            }

            string fileName = $"qr_{DateTime.Now.Ticks}";
            _qr.GenerateQrToFile(text, fileName);

            return Ok(fileName); // فقط نام فایل
        }
        [HttpGet("ReadQr")]
        public IActionResult ReadQr([FromQuery] string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return BadRequest("FileName cannot be empty");

            // مسیر واقعی فایل QR
            string qrFilesPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "QrFiles"));
            string filePath = Path.Combine(qrFilesPath, fileName + ".png");

            if (!System.IO.File.Exists(filePath))
                return NotFound($"File not found: {filePath}");

            try
            {
                var qrReader = new QrReaderService();
                var text = qrReader.ReadQrFromFile(filePath);

                if (string.IsNullOrEmpty(text))
                    return BadRequest("خواندن متن QR ناموفق بود");

                return Ok(text);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطا در خواندن QR: {ex.Message}");
            }
        }

        [HttpPost("GenerateBatch")]
        public IActionResult GenerateBatch([FromBody] string longText)
        {
            if (string.IsNullOrWhiteSpace(longText))
            {
                return BadRequest("Text cannot be empty");
            }

            var files = _qrBatch.GenerateMultipleQrs(longText);

            return Ok(files);
        }
        [HttpGet("Generate1")]
        public IActionResult GenerateQr([FromQuery] string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return BadRequest("Text cannot be empty");
            }

            string fileName = $"qr_{DateTime.Now.Ticks}";

            // مسیر کامل فقط داخل سرور استفاده می‌شود
            _qr.GenerateQrToFile(text, fileName);

            // بازگرداندن فقط نام فایل
            return Ok(fileName);
        }
        [HttpGet("GetQrFile")]
        public IActionResult GetQrFile([FromQuery] string fileName)
        {
            string solutionRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\.."));
            string filePath = Path.Combine(solutionRoot, "QrFiles", fileName + ".png");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound($"File not found: {filePath}");
            }

            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/png");
        }


    }
}
