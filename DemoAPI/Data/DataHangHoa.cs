using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPI.Data
{
    [Table("HangHoa")]
    public class DataHangHoa
    {
        [Key]
        public Guid MaHH { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenHH { get; set; }

        public string Mota {  get; set; }

        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }

        public byte GiamGia { get; set; }
        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public LoaiHH LoaiHH { get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DataHangHoa()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }
    }
}
