using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPI.Data
{
    [Table("LoaiHH")]
    public class LoaiHH
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(255)]
        public string TenLoai { get; set; }
        public virtual ICollection<DataHangHoa> HangHoas { get; set; }
    }
}
