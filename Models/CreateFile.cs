namespace APIService.Models
{
    public class CreateFile
    {
        public int? Userid { get; set; }
        public string? Filename { get; set; }
        public string? AccessRole { get; set; }
        public IFormFile? FileData { get; set; }
    }
}
