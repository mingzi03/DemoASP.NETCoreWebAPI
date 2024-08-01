using DemoAPI.Data;
using DemoAPI.Model;

namespace DemoAPI.Services
{
    public class LoaiRepo : ILoaiRepository
    {
        private readonly HangHoaContext _context;

        public LoaiRepo(HangHoaContext context)
        {
            _context = context;

        }

        public LoaiTraVe Add(ModelLoai loai)
        {
            var _loai = new LoaiHH
            {
                TenLoai = loai.TenLoai,
            };
            _context.Add(_loai);
            _context.SaveChanges();

            return new LoaiTraVe
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai,
            };

        }

        public void Delete(int id)
        {
            var loai = _context.LoaiHHs.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            };
        }

        public List<LoaiTraVe> GetAll()
        {
            var loais = _context.LoaiHHs.Select(lo => new LoaiTraVe
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai
            }
                );
            return loais.ToList();
        }

        public LoaiTraVe GetById(int id)
        {
            var loai = _context.LoaiHHs.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                return new LoaiTraVe
                {
                    MaLoai = loai.MaLoai,
                    TenLoai= loai.TenLoai
                };
            }
            return null;
        }

        public void Update(LoaiTraVe loai)
        {
            var _loai = _context.LoaiHHs.SingleOrDefault(lo => lo.MaLoai == loai.MaLoai);
            loai.TenLoai = _loai.TenLoai;
            _context.SaveChanges();
        }
    }
}
