using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameMangementSystem.Models
{
    /// <summary>
    /// model for game 
    /// </summary>
    public class Game
    {
        //ID
        public int ID { get; set; }
        //Title is required, max length is 60 characters, min 3
        [StringLength(60, MinimumLength = 3)]
        //any number character of - a-z upper or lower case as well as
        //space & ! or any digit
        [RegularExpression(@"[\-A-Za-z &!\d]*")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        //Any number of charters which are - a-z A-Z or space
        [RegularExpression(@"[\-A-Za-z ]*")]
        [Required]
        public string Genre { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal Price { get; set; }
    }
}
