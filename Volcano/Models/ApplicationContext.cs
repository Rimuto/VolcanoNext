using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Volcano.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Volcanos> Vulk { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public ApplicationContext()
        {
        }
    }
}
