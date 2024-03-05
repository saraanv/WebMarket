using Microsoft.EntityFrameworkCore;
using WebMarket.Web.Models;

namespace WebMarket.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext>options ) : base(options)
        { }

        public DbSet<Category> Categories { get; set; }

    }
}
