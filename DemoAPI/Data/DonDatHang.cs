namespace DemoAPI.Data
{

    public enum TrangThaiDonHang
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }

    public class DonDatHang
    {
        public Guid MaDH { get; set; }
        public DateTime Ngaydathang { get; set; }
        public DateTime? Ngaygiaohang { get; set; }
        public int TrangThai { get; set; }
        public string Nguoinhanhang { get; set; }
        public string DiachiGiaohang { get; set; }
        public string Sodienthoai { get; set; }
        
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DonDatHang()
        {
            ChiTietDonHangs = new List<ChiTietDonHang>();
        }

    }
}
