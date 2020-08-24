using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vroom.Models
{
    public class VroomAppDbContext : DbContext
    {
        public VroomAppDbContext(DbContextOptions<VroomAppDbContext> options) : base(options)
        {

        }


        //map to database where crud operations happen
        public DbSet <Model> Models{ get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }

    }
}
