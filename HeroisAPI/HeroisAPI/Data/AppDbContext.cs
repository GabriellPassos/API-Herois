using Microsoft.EntityFrameworkCore;
using HeroisAPI.Models;

namespace HeroisAPI.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Heroi> Herois { get; set; }
        public virtual DbSet<SuperPoder> SuperPoderes { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
