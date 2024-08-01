using DemoAPI.Model;

namespace DemoAPI.Data
{
    public class ChiTietDonHang
    {
        public Guid MaHH { get; set; }
        public Guid MaDH { get; set; }
        public int Soluong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        public DonDatHang DonDatHang { get; set; }
        public DataHangHoa DataHangHoa { get; set; }


    }
}
