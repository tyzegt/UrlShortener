using Microsoft.EntityFrameworkCore;
using UrlShortener.Web.DbModels;

namespace UrlShortener.Web.DbService 
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Link> Links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstring = "Server = (localdb)\\MSSQLLocalDB; Database = UrlShortener; Trusted_Connection = True";
            optionsBuilder.UseSqlServer(connstring);
        }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
    }
}
