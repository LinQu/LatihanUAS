using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LatihanUAS.Data;
using LatihanUAS.Models;


namespace LatihanUAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaryawanController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public KaryawanController(ApplicationDbContext db)
        {
            _db = db;
        }

        //ini buat ambil semua data
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Karyawan>>> GetKaryawan()
        {
            IEnumerable<Karyawan> karyawan = await _db.Karyawan.ToListAsync();
            return Ok(karyawan);
        }

        //ini buat create
        [HttpPost("Create/")]
        public async Task<ActionResult<Karyawan>> CreateKaryawan(Karyawan karyawan)
        {
            _db.Karyawan.Add(karyawan);
            await _db.SaveChangesAsync();
            return Ok(karyawan);
        }

        //ini buat update
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateKaryawan(int id, Karyawan karyawan)
        {
            if (id != karyawan.id)
            {
                return BadRequest();
            }

            _db.Entry(karyawan).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KaryawanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //ini buat delete
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteKaryawan(int id)
        {
            var karyawan = await _db.Karyawan.FindAsync(id);
            if (karyawan == null)
            {
                return NotFound();
            }

            _db.Karyawan.Remove(karyawan);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool KaryawanExists(int id)
        {
            return _db.Karyawan.Any(e => e.id == id);
        }
        
    }
}
