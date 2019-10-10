using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameMangementSystem.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseData { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
