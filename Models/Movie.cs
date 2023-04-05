using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureTest.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        
        [Display(Name ="Release Date")]                 // Set the column name
        [DataType(DataType.Date)]                       // Set the SQL data type to Date
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }

        [Column(TypeName = "decimal(18, 2)")]           // Set the SQL data type to currency
        public decimal Price { get; set; }  
    }
}
