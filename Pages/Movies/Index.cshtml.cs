using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AzureTest.Data;
using AzureTest.Models;

namespace AzureTest.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly AzureTest.Data.AzureTestContext _context;

        public IndexModel(AzureTest.Data.AzureTestContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
