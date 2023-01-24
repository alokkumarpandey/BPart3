using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabEntity.Shared;

namespace BlazorDemoPart2.Server.Data
{
    public class BlazorDemoPart2ServerContext : DbContext
    {
        public BlazorDemoPart2ServerContext (DbContextOptions<BlazorDemoPart2ServerContext> options)
            : base(options)
        {
        }

        public DbSet<LabEntity.Shared.Customer> Customer { get; set; } = default!;

        public DbSet<LabEntity.Shared.Country> Country { get; set; } = default!;
    }
}
