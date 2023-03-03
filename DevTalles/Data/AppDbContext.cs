using DevTalles.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTalles.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Curso> Cursos { get; set; }
       
    }
}
