using OpenCvSharp;
using OpenCvSharp.Dnn;
using System;
using System.Collections.Generic;
using System.IO;

namespace ShamsAlShamoos01.Infrastructure.Services
{
    public interface IFaceRecognitionService
    {
        List<string> FindSimilarFaces(string targetImagePath, string folderPath, double threshold = 0.6);
    }

    public class FaceRecognitionService : IFaceRecognitionService
    {
        private readonly Net _faceDetector;
        private readonly Net _faceEmbedder;

        public FaceRecognitionService()
        {
            string basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "face_models");

            // Load face detector
            string protoPath = Path.Combine(basePath, "deploy.prototxt");
            string modelPath = Path.Combine(basePath, "res10_300x300_ssd_iter_140000.caffemodel");
            if (!File.Exists(protoPath) || !File.Exists(modelPath))
                throw new FileNotFoundException("Face detector model files missing");

            _faceDetector = CvDnn.ReadNetFromCaffe(protoPath, modelPath);

            // Load face embedder
            string embedderPath = Path.Combine(basePath, "openface_nn4.small2.v1.t7");
            if (!File.Exists(embedderPath))
                throw new FileNotFoundException("Face embedder model file missing");

            _faceEmbedder = CvDnn.ReadNetFromTorch(embedderPath);
        }
        public List<string> FindSimilarFaces(string targetImagePath, string folderPath, double threshold = 0.2)
        {
//            جمع‌بندی

//برای کم کردن حساسیت، توصیه اصلی من:

//            threshold در FindSimilarFaces را بزرگتر کنید(مثلاً 0.7 یا 0.75).

//در صورت نیاز، confidenceThreshold در DetectFaces را کمی کاهش دهید.

//این دو تغییر کافی است بدون اینکه کدهای اصلی را تغییر دهید

            var matches = new List<string>();
            string resultFolder = @"D:\upload\Result01";

            // بررسی وجود فایل هدف
            if (!File.Exists(targetImagePath))
            {
                Console.WriteLine("Target image file not found.");
                return matches;
            }

            // ایجاد پوشه نتیجه در صورت عدم وجود
            if (!Directory.Exists(resultFolder))
                Directory.CreateDirectory(resultFolder);

            var targetEmbeddings = GetEmbeddings(targetImagePath);

            if (targetEmbeddings == null || targetEmbeddings.Count == 0)
            {
                Console.WriteLine("No face detected in target image.");
                return matches;
            }

            // فقط از اولین چهره در تصویر هدف استفاده می‌کنیم
            var targetEmbedding = targetEmbeddings[0];

            foreach (var file in Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                .Where(f => f.ToLower().EndsWith(".jpg") || f.ToLower().EndsWith(".jpeg") ||
                           f.ToLower().EndsWith(".png") || f.ToLower().EndsWith(".bmp")))
            {
                var embeddings = GetEmbeddings(file);
                if (embeddings == null || embeddings.Count == 0)
                {
                    Console.WriteLine($"No face detected in file: {Path.GetFileName(file)}");
                    continue;
                }

                // مقایسه با تمام چهره‌های موجود در تصویر
                foreach (var emb in embeddings)
                {
                    double dist = CosineDistance(targetEmbedding, emb);
                    Console.WriteLine($"Distance to {Path.GetFileName(file)}: {dist:F4}");

                    if (dist < threshold)
                    {
                        matches.Add(file);

                        // کپی فایل به پوشه نتیجه
                        string destPath = Path.Combine(resultFolder, Path.GetFileName(file));
                        try
                        {
                            File.Copy(file, destPath, overwrite: true);
                            Console.WriteLine($"Copied {Path.GetFileName(file)} to result folder.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to copy {Path.GetFileName(file)}: {ex.Message}");
                        }

                        break; // اگر یک چهره مشابه پیدا شد، به فایل بعدی برو
                    }
                }
            }

            return matches;
        }

        public List<string> FindSimilarFaces22(string targetImagePath, string folderPath, double threshold = 0.6)
        {
            var matches = new List<string>();

            // بررسی وجود فایل هدف
            if (!File.Exists(targetImagePath))
            {
                Console.WriteLine("Target image file not found.");
                return matches;
            }

            var targetEmbeddings = GetEmbeddings(targetImagePath);

            if (targetEmbeddings == null || targetEmbeddings.Count == 0)
            {
                Console.WriteLine("No face detected in target image.");
                return matches;
            }

            // فقط از اولین چهره در تصویر هدف استفاده می‌کنیم
            var targetEmbedding = targetEmbeddings[0];

            foreach (var file in Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                .Where(f => f.ToLower().EndsWith(".jpg") || f.ToLower().EndsWith(".jpeg") ||
                           f.ToLower().EndsWith(".png") || f.ToLower().EndsWith(".bmp")))
            {
                var embeddings = GetEmbeddings(file);
                if (embeddings == null || embeddings.Count == 0)
                {
                    Console.WriteLine($"No face detected in file: {Path.GetFileName(file)}");
                    continue;
                }

                // مقایسه با تمام چهره‌های موجود در تصویر
                foreach (var emb in embeddings)
                {
                    double dist = CosineDistance(targetEmbedding, emb);
                    Console.WriteLine($"Distance to {Path.GetFileName(file)}: {dist:F4}");

                    if (dist < threshold)
                    {
                        matches.Add(file);
                        break; // اگر یک چهره مشابه پیدا شد، به فایل بعدی برو
                    }
                }
            }

            return matches;
        }

        private List<float[]> GetEmbeddings(string imagePath)
        {
            Mat img = Cv2.ImRead(imagePath);
            if (img.Empty())
            {
                Console.WriteLine($"Failed to read image: {imagePath}");
                return null;
            }

            var faces = DetectFaces(img);
            if (faces.Count == 0)
                return null;

            var embeddings = new List<float[]>();

            foreach (var face in faces)
            {
                Mat faceImg = new Mat(img, face);

                // پیش‌پردازش بهتر برای embedder
                Mat blob = CvDnn.BlobFromImage(faceImg, 1.0 / 255, new Size(96, 96),
                    new Scalar(0, 0, 0), true, false);

                _faceEmbedder.SetInput(blob);
                Mat output = _faceEmbedder.Forward();

                // تبدیل خروجی به آرایه
                output.GetArray(out float[] embedding);

                // نرمال‌سازی embedding
                NormalizeVector(embedding);

                embeddings.Add(embedding);
            }

            return embeddings;
        }

        private List<Rect> DetectFaces(Mat img, float confidenceThreshold = 0.2f)
        {
            //در صورت نیاز، confidenceThreshold در DetectFaces را کمی کاهش دهید.
            var faces = new List<Rect>();

            // ایجاد blob با پارامترهای صحیح برای detector
            int targetWidth = 300;
            int targetHeight = 300;

            Mat blob = CvDnn.BlobFromImage(img, 1.0, new Size(targetWidth, targetHeight),
                new Scalar(104, 177, 123), false, false);

            _faceDetector.SetInput(blob);
            Mat detections = _faceDetector.Forward();

            int width = img.Cols;
            int height = img.Rows;

            for (int i = 0; i < detections.Size(2); i++)
            {
                float confidence = detections.At<float>(0, 0, i, 2);
                if (confidence > confidenceThreshold)
                {
                    int x1 = (int)(detections.At<float>(0, 0, i, 3) * width);
                    int y1 = (int)(detections.At<float>(0, 0, i, 4) * height);
                    int x2 = (int)(detections.At<float>(0, 0, i, 5) * width);
                    int y2 = (int)(detections.At<float>(0, 0, i, 6) * height);

                    // اطمینان از قرار گرفتن مختصات در محدوده تصویر
                    x1 = Math.Max(0, Math.Min(x1, width - 1));
                    y1 = Math.Max(0, Math.Min(y1, height - 1));
                    x2 = Math.Max(0, Math.Min(x2, width - 1));
                    y2 = Math.Max(0, Math.Min(y2, height - 1));

                    int faceWidth = x2 - x1;
                    int faceHeight = y2 - y1;

                    // فیلتر کردن چهره‌های بسیار کوچک
                    if (faceWidth > 20 && faceHeight > 20)
                    {
                        faces.Add(new Rect(x1, y1, faceWidth, faceHeight));
                    }
                }
            }

            return faces;
        }

        private void NormalizeVector(float[] vector)
        {
            double sum = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                sum += vector[i] * vector[i];
            }

            double norm = Math.Sqrt(sum);
            if (norm > 1e-6)
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i] = (float)(vector[i] / norm);
                }
            }
        }

        private double CosineDistance(float[] a, float[] b)
        {
            if (a.Length != b.Length)
                return 1.0;

            double dot = 0, na = 0, nb = 0;
            for (int i = 0; i < a.Length; i++)
            {
                dot += a[i] * b[i];
                na += a[i] * a[i];
                nb += b[i] * b[i];
            }

            na = Math.Sqrt(na);
            nb = Math.Sqrt(nb);

            if (na < 1e-6 || nb < 1e-6)
                return 1.0;

            double similarity = dot / (na * nb);
            return 1.0 - similarity; // تبدیل similarity به distance
        }
    }
}