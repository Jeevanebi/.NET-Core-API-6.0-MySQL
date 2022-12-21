using System;
using System.Collections.Generic;

namespace APIService.Models
{
    public partial class Userfile
    {
        public int FileId { get; set; }
        public int? Userid { get; set; }
        public string? Filename { get; set; }
        public string? Type { get; set; }
        public string? AccessRole { get; set; }
        public string? Size { get; set; }
        public string? FileData { get; set; }
        public string? CreatedAt { get; set; }
        public string? LastModified { get; set; }

        public virtual User? User { get; set; }
    }
}
