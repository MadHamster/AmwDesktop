using System.ComponentModel.DataAnnotations;

namespace AmwDesktop.Data.Models
{
    public class MediaFile
    {
        [Key]
        public string Path { get; set; }
    }
}
