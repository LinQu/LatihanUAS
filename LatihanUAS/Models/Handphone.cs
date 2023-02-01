using System.ComponentModel.DataAnnotations;

namespace LatihanUAS.Models
{
    public class Handphone
    {
        [Key]
        public int id { get; set; }
        public string? Merk { get; set; }
        public string? Tipe { get; set; }
        public int? Harga { get; set; }
        public int? Stock { get; set; }
    }
}
