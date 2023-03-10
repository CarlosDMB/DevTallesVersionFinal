using DevTalles.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTalles.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categoriass { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Curso> Cursos { get; set; }
       
    }
}
