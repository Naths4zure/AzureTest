using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureTest.Models;
using Microsoft.EntityFrameworkCore;

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
