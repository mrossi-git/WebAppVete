using Microsoft.EntityFrameworkCore;
using WebAppVete.Models;

namespace WebAppVete.Data
{
    public class AppDBcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Veterinaria;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Especie> Especies { get; set; }
    }
}
