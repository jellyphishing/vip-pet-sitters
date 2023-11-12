using Microsoft.AspNetCore.Http;

namespace file.Model
{
    public class FileModel
    {
        public string Insurance { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
