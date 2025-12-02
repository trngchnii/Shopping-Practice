using api.Interfaces;

namespace api.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folderName = "products")
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("No file uploaded");

            var webRoot = _environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            // Ensure the "products" directory exists
            var dir = Path.Combine(webRoot, "products");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var path = Path.Combine(dir, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/{folderName}/{fileName}";
        }
    }
}