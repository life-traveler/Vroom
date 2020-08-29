using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vroom.Models
{
    public class VroomAppDbContext :IdentityDbContext<IdentityUser>
    {
        public VroomAppDbContext(DbContextOptions<VroomAppDbContext> options) : base(options)
        {

        }


        //map to database where crud operations happen
        public DbSet <Model> Models{ get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Feature> Features { get; set; }

    }
}
