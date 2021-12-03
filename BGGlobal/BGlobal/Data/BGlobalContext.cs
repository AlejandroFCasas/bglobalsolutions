using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BGlobal.Models;

namespace BGlobal.Data
{
    public class BGlobalContext : DbContext
    {
        public BGlobalContext (DbContextOptions<BGlobalContext> options)
            : base(options)
        {
        }

        public DbSet<BGlobal.Models.Vehiculo> Vehículo { get; set; }
    }
}
