using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrouwerWebApp.Models;

namespace BrouwerWebApp.Repositories
{
    public class BierlandContext : DbContext
    {
        public BierlandContext(DbContextOptions<BierlandContext> options) : base(options) { }
        public DbSet<Brouwer> Brouwers { get; set; }
    }
}
