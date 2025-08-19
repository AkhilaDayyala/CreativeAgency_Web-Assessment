using System.Text.Json;
using Web.CreativeAgency.Models;

namespace Web.CreativeAgency.Services
{
    public class FileContactService : IContactService
    {
        private readonly string _filePath;

        public FileContactService(IWebHostEnvironment env)
        {
            var dataDir = Path.Combine(env.ContentRootPath, "App_Data");
            Directory.CreateDirectory(dataDir);
            _filePath = Path.Combine(dataDir, "contact-submissions.json");
        }

        public async Task SaveAsync(ContactFormModel model)
        {
            var list = new List<ContactFormModel>();
            if (File.Exists(_filePath))
            {
                using var rs = File.OpenRead(_filePath);
                var existing = await JsonSerializer.DeserializeAsync<List<ContactFormModel>>(rs);
                if (existing != null) list = existing;
            }
            list.Add(model);
            var opts = new JsonSerializerOptions { WriteIndented = true };
            await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(list, opts));
        }
    }
}
