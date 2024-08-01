using DemoAPI.Model;

namespace DemoAPI.Services
{
    public interface ILoaiRepository
    {
        List<LoaiTraVe> GetAll();
        LoaiTraVe GetById(int id);
        LoaiTraVe Add(ModelLoai loai);
        void Update(LoaiTraVe loai);
        void Delete(int id);
    }
}
