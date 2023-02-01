using Microsoft.EntityFrameworkCore;
using LatihanUAS.Models;

namespace LatihanUAS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Handphone> Handphone { get; set; }
        public DbSet<Karyawan> Karyawan { get; set; }
        public DbSet<Transaksi> Transaksi { get; set; }
    }
}
