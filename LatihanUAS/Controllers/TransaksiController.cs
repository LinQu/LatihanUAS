using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LatihanUAS.Data;
using LatihanUAS.Models;

namespace LatihanUAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TransaksiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TransaksiController(ApplicationDbContext db)
        {
            _db = db;
        }

        //ini buat ambil semua data
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Transaksi>>> GetTransaksi()
        {
            IEnumerable<Transaksi> transaksi = await _db.Transaksi.ToListAsync();
            return Ok(transaksi);
        }

        //ini buat create
        [HttpPost("Create/")]
        public async Task<ActionResult<Transaksi>> CreateTransaksi(Transaksi transaksi)
        {
            _db.Transaksi.Add(transaksi);
            await _db.SaveChangesAsync();
            var handphone = _db.Handphone.Find(transaksi.idHp);
            if (handphone.Stock >= transaksi.Jumlah)
            {
                handphone.Stock = handphone.Stock - transaksi.Jumlah;
                _db.Entry(handphone).State = EntityState.Modified;
                _db.SaveChanges();
            }
            return Ok(transaksi);
            //return CreatedAtAction("KurangStock", new { id = transaksi.id,qty = transaksi.Jumlah }, transaksi);
        }

        [HttpGet("Detail1")]
        public async Task<ActionResult<IEnumerable<Transaksi>>> GetDetail1()
        {
            var Detail = (from trs in _db.Transaksi
                          join hp in _db.Handphone on trs.idHp equals hp.id
                          join kry in _db.Karyawan on trs.idKaryawan equals kry.id
                          select new DetailTransaksi1
                          {
                              id = trs.id,
                              idHp = trs.idHp,
                              idKaryawan = trs.idKaryawan,
                              Jumlah = trs.Jumlah,
                              TotalHarga = trs.TotalHarga,
                              Tanggal = trs.Tanggal,
                              NamaHp = hp.Tipe,
                              NamaKaryawan = kry.Nama
                          }).ToList();
            return Ok(Detail);

        }


        //ini buat detail transkasi opsional ya bisa pilih yang atas atau bawah
        [HttpGet("Detail")]
        public async Task<ActionResult<IEnumerable<Transaksi>>> GetDetail()
        {
            var Detail = (from trs in _db.Transaksi
                          select new DetailTransaksi
                          {
                              id = trs.id,
                              idHp = trs.idHp,
                              idKaryawan = trs.idKaryawan,
                              Jumlah = trs.Jumlah,
                              TotalHarga = trs.TotalHarga,
                              Tanggal = trs.Tanggal,
                              Handphone = (from hp in _db.Handphone
                                           where hp.id == trs.idHp
                                           select new Handphone
                                           {
                                               id = hp.id,
                                               Merk = hp.Merk,
                                               Tipe = hp.Tipe,
                                               Harga = hp.Harga,
                                               Stock = hp.Stock
                                           }).ToList(),
                              Karyawan = (from kry in _db.Karyawan
                                          where kry.id == trs.idKaryawan
                                          select new Karyawan
                                          {
                                              id = kry.id,
                                              Nama = kry.Nama,
                                              NoTelp = kry.NoTelp,
                                              Email = kry.Email,
                                          }).ToList()
                          }).ToList();
            return Ok(Detail);

        }
        

    }
}
