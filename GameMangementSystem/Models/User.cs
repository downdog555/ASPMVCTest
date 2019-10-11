using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameMangementSystem.Models
{
    public class Users
    {
        public int ID { get; set; }
        [RegularExpression(@"[\-A-Za-z_@&!\d]*")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Username { get; set; }
        [RegularExpression(@"[\-A-Za-z_@&!\d]*")]
        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Password { get; set; }
    }
}
