using DemoAPI.Data;
using DemoAPI.Model;

namespace DemoAPI.Services
{
    public class HangHoaRepo : IHangHoaRepository
    {
        private readonly HangHoaContext _context;

        public HangHoaRepo(HangHoaContext context)
        {
            _context = context;
        }
        public List<HangHoaModel> GetAll(string search)
        {
            var allProducts = _context.HangHoas.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(hh => hh.TenHH.Contains(search));
            }

            var result = allProducts.Select(hh => new HangHoaModel
            {
                MaHangHoa =hh.MaHH,
                TenhangHoa = hh.TenHH,
                DonGia = hh.DonGia,
                TenLoai = hh.LoaiHH.TenLoai,
            });

            return result.ToList();
        }
    }
}
