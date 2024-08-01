using DemoAPI.Model;

namespace DemoAPI.Services
{
    public interface IHangHoaRepository
    {
        List<HangHoaModel> GetAll(string search);
    }
}
