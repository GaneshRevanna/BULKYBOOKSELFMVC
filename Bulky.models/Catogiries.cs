using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.models
{
    public class Catogiries
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display order")]
        [Range(1, 100)]
        public int displayorder { get; set; }
    }
}
