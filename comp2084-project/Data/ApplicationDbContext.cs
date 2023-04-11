using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using comp2084_project.Models;

namespace comp2084_project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<comp2084_project.Models.Movie> Movie { get; set; }
        public DbSet<comp2084_project.Models.CinemaRoom> CinemaRoom { get; set; }
       
    }
    

}