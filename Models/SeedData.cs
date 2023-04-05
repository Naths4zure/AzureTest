using AzureTest.Data;
using Microsoft.EntityFrameworkCore;

namespace AzureTest.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AzureTestContext(                                          // Create a context for the database 
                serviceProvider.GetRequiredService<DbContextOptions<AzureTestContext>>()))      
            {
                if(context == null || context.Movie == null)                                    // If the database or table do not exist
                {
                    throw new ArgumentNullException("Null AzureTestContext");                   //  throw an exception 
                }

                if(context.Movie.Any())                                                         // If the database contains movies
                {
                    return;                                                                     //  exit seeding data     
                }

                context.Movie.AddRange(                                 // Add movies
                    new Movie
                    {
                        Title = "Shrek",                                // Shrek 
                        ReleaseDate = DateTime.Parse("2001-05-18"),     
                        Genre = "Animation",
                        Price = 3.5M
                    },
                    new Movie
                    {
                        Title = "The Matrix",                           // The Matrix 
                        ReleaseDate = DateTime.Parse("1999-03-31"),
                        Genre = "Sci Fi",
                        Price = 4.00M
                    },

                    new Movie
                    {
                        Title = "A Knights Tale",                       // A Knights Tale
                        ReleaseDate = DateTime.Parse("2001-05-11"),
                        Genre = "Comedy",
                        Price = 3.00M
                    },

                    new Movie
                    {
                        Title = "Back to the Future",                   // Back to the Future
                        ReleaseDate = DateTime.Parse("1985-07-03"),
                        Genre = "Sci Fi",
                        Price = 2.5M
                    }
                );                                                      //  end of Add movies


                context.SaveChanges();                                  // Save changes to teh database  
            }
        }
    }
}
