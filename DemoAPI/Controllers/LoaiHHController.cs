using DemoAPI.Data;
using DemoAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHHController : ControllerBase
    {
        private readonly HangHoaContext _context;

        public LoaiHHController(HangHoaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsLoai = _context.LoaiHHs.ToList();
                return Ok(dsLoai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.LoaiHHs.SingleOrDefault(lo => 
            lo.MaLoai == id);
            if (loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }

       [HttpPost]
       [Authorize]
       public IActionResult CreateNew(ModelLoai model)
       {
            try
            {
                var loai = new LoaiHH
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, loai);
            }
            catch
            {
                return BadRequest();
            }
       }

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, ModelLoai model)
        {
            var loai = _context.LoaiHHs.SingleOrDefault(lo =>
            lo.MaLoai == id);
            if (loai != null)
            {
                //Update
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoaiById(int id)
        {
            var loai = _context.LoaiHHs.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
