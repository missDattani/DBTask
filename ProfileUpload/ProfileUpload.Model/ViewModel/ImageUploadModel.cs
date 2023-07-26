using Microsoft.AspNetCore.Http;

namespace ProfileUpload.Models
{
    public class ImageUploadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string ProfilePic { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
