namespace MyAcademy_PortfolioProject.Helpers
{
    public static class ImageHelper
    {
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long MaxSize = 2 * 1024 * 1024; // 2 MB

        // Görseli wwwroot/images/{folder} içine kaydeder, veritabanına yazılacak yolu döndürür
        public static string? Save(IFormFile? file, string folder, out string? error)
        {
            error = null;
            if (file == null || file.Length == 0)
                return null;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(extension))
            {
                error = "Sadece jpg, jpeg, png veya webp yükleyebilirsiniz.";
                return null;
            }

            if (file.Length > MaxSize)
            {
                error = "Görsel en fazla 2 MB olabilir.";
                return null;
            }

            var fileName = Guid.NewGuid() + extension;
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", folder);
            Directory.CreateDirectory(directory);

            using (var stream = new FileStream(Path.Combine(directory, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"/images/{folder}/{fileName}";
        }

        // Sadece bizim yüklediğimiz (/images/ ile başlayan) dosyaları siler
        public static void Delete(string? imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl) || !imageUrl.StartsWith("/images/"))
                return;

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imageUrl.TrimStart('/'));
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}