using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using ZXing;
using ZXing.ImageSharp;

namespace ShamsAlShamoos01.Infrastructure.Services
{
    public class QrReaderService
    {
        public string ReadQrFromFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return null; 
            }

            using var image = Image.Load<Rgba32>(filePath);

            // استفاده از BarcodeReader اختصاصی ImageSharp
            var reader = new ZXing.ImageSharp.BarcodeReader<Rgba32>
            {
                AutoRotate = true,
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true
                }
            };

            var result = reader.Decode(image);
            return result?.Text;
        }
    }
}
