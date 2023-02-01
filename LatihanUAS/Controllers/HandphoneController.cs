using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LatihanUAS.Data;
using LatihanUAS.Models;

namespace LatihanUAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandphoneController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public HandphoneController(ApplicationDbContext db)
        {
            _db = db;
        }

        //ini buat ambil semua data
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Handphone>>> GetHandphone()
        {
            IEnumerable<Handphone> handphone = await _db.Handphone.ToListAsync();
            return Ok(handphone);
        }

        //ini buat create
        [HttpPost("Create/")]
        public async Task<ActionResult<Handphone>> CreateHandphone(Handphone handphone)
        {
            _db.Handphone.Add(handphone);
            await _db.SaveChangesAsync();
            return Ok(handphone);
        }

        //ini buat update
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateHandphone(int id,Handphone handphone)
        {
            if (id != handphone.id)
            {
                return BadRequest();
            }

            _db.Entry(handphone).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HandphoneExists(id))
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

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Handphone>> DeleteHandphone(int id)
        {
            var handphone = await _db.Handphone.FindAsync(id);
            if (handphone == null)
            {
                return NotFound();  
            }

            _db.Handphone.Remove(handphone);
            await _db.SaveChangesAsync();

            return handphone;
        }

        ////[HttpPost]

        private bool HandphoneExists(int id)
        {
            return _db.Handphone.Any(e => e.id == id);
        }

    }
}
