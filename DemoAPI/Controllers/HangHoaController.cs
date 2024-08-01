using DemoAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hanghoas = new List<HangHoa>();

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(hanghoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                // LINQ [Object] Query
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
           catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hanghoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hanghoaVM.TenHangHoa,
                DonGia = hanghoaVM.DonGia
            };
            hanghoas.Add(hanghoa);
            return Ok(new
            {
                success = true, 
                Data = hanghoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hanghoaEdit)
        {
            try
            {
                // LINQ [Object] Query
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }

                if( id != hanghoa.MaHangHoa.ToString() )
                {
                    return BadRequest();
                }

                // Update
                hanghoa.TenHangHoa = hanghoaEdit.TenHangHoa;
                hanghoa.DonGia = hanghoaEdit.DonGia;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                // LINQ [Object] Query
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }

                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }

                // Delete
                hanghoas.Remove(hanghoa);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
