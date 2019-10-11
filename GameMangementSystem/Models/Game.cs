using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameMangementSystem.Models
{
    public class Game
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"/[A-Z &!\d]/gi")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"/[A-Z ]/gi")]
        [Required]
        public string Genre { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal Price { get; set; }
    }
}
