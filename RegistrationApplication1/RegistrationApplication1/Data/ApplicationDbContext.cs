using Microsoft.EntityFrameworkCore;
using RegistrationApplication1.Models.Domain;

namespace RegistrationApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        //new constructor 
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //creating tables

        public DbSet<Company> Companies {  get; set; }
        


    }
}
