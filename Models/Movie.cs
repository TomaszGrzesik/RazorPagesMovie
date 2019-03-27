using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    ///Summary:
    ///Model class contains fields properties and validators which keep DRY principle
    ///
    public class Movie
    {
        public int ID { get; set; }

        // Required - prop must have a value
        //StringLength sets the maximum length of a string, and optionally the minimum legth
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        //Display attribute specifies what to display for the name of a field
        //in this case "Release Date" instead of "ReleaseDate"
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        //RegularExpression limits the characters that user can enter
        //Genre must start with one or more capital letters and follow with zero or mire letters, single/doublke quotes, whitespace, dashes
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }
        
        //Range attribute constrains a value to specific range
        //data annotation enables EF Core to correctly map Price to currency in DB
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        //Rating  must start withnone or more capital letters and follow with zero or more letter, numbers, single/doublke quotes, whitespace, dashes
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}