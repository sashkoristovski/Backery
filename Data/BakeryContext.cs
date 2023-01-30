using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bakery.Models;

namespace Bakery.Data
{
    public class BakeryContext : DbContext
    {
        public BakeryContext (DbContextOptions<BakeryContext> options)
            : base(options)
        {
        }

        public DbSet<Bakery.Models.Product> Products { get; set; } = default!;
    }
}
