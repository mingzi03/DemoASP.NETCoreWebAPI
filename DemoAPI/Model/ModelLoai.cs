using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Model
{
    public class ModelLoai
    {
        [Required]
        [MaxLength(255)]
        public string TenLoai { get; set; }
    }
}
