using BrowserTravelDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelInfraestructure.Persistence
{
    public class BrowserTravelCoreApiDbContext : DbContext
    {
        public BrowserTravelCoreApiDbContext(DbContextOptions options) : base(options)
        {

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Autors> Autores { get; set; }
        public DbSet<AutorHasLibro> AutorHasLibros { get; set; }
        public DbSet<Editorials> Editoriales { get; set; }
        public DbSet<Libros> Libros { get; set; }
    }
}
