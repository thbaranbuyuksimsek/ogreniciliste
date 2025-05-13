using Microsoft.EntityFrameworkCore;
using Bilisim.HelloMvc.Models;

namespace Bilisim.HelloMvc.Data
{
    public class OgrenciDbContext : DbContext
    {
        public OgrenciDbContext(DbContextOptions<OgrenciDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
    }
}
