using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LatihanUAS.Models
{
    public class DetailTransaksi1
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Handphone")]
        public int idHp { get; set; }
        public string? NamaHp { get; set; }

        [ForeignKey("Karyawan")]
        public int idKaryawan { get; set; }
        public string? NamaKaryawan { get; set; }

        public int? Jumlah { get; set; }
        public int? TotalHarga { get; set; }

        public DateTime Tanggal { get; set; } = DateTime.Now;
    }
}
