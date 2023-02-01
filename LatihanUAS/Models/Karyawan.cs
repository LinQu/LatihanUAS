using System.ComponentModel.DataAnnotations;

namespace LatihanUAS.Models
{
    public class Karyawan
    {
        [Key]
        public int id { get; set; }

        public string? Nama { get; set; }
        public string? Email { get; set; }
        public string? NoTelp { get; set; }
    }
}
