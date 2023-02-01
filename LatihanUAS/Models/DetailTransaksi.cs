using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LatihanUAS.Models
{
    public class DetailTransaksi
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Handphone")]
        public int idHp { get; set; }
        public List<Handphone>? Handphone { get; set; }

        [ForeignKey("Karyawan")]
        public int idKaryawan { get; set; }
        public List<Karyawan> Karyawan { get; set; }

        public int? Jumlah { get; set; }
        public int? TotalHarga { get; set; }

        public DateTime Tanggal { get; set; } = DateTime.Now;
    }
}
