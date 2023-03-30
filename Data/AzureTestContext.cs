using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AzureTest.Models;

namespace AzureTest.Data
{
    public class AzureTestContext : DbContext
    {
        public AzureTestContext (DbContextOptions<AzureTestContext> options)
            : base(options)
        {
        }

        public DbSet<AzureTest.Models.Movie> Movie { get; set; } = default!;
    }
}
