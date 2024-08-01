using DemoAPI.Model;

namespace DemoAPI.Services
{
    public class LuuTruLoaiRepo : ILoaiRepository
    {
        static List<LoaiTraVe> loais = new List<LoaiTraVe>
        {
            new LoaiTraVe{ MaLoai = 1, TenLoai = "Tivi"},
            new LoaiTraVe{ MaLoai = 2, TenLoai = "Tu lanh"},
            new LoaiTraVe{ MaLoai = 3, TenLoai = "May giat"},
            new LoaiTraVe{ MaLoai = 4, TenLoai = "Dieu hoa"},

        };
        public LuuTruLoaiRepo() {
        }
        public LoaiTraVe Add(ModelLoai loai)
        {
            var _loai = new LoaiTraVe
            {
                MaLoai = loais.Max(lo => lo.MaLoai) + 1,
                TenLoai = loai.TenLoai,
            };
            loais.Add(_loai);
            return _loai;
        }

        public void Delete(int id)
        {
            var _loai = loais.SingleOrDefault(lo => lo.MaLoai == id);
            loais.Remove(_loai);
        }

        public List<LoaiTraVe> GetAll()
        {
            return loais;
        }

        public LoaiTraVe GetById(int id)
        {
            return loais.SingleOrDefault(lo => lo.MaLoai == id);
        }

        public void Update(LoaiTraVe loai)
        {
            var _loai = loais.SingleOrDefault(lo => lo.MaLoai == loai.MaLoai);
            if (_loai != null)
            {
                _loai.TenLoai = loai.TenLoai;
            };
        }
    }
}
