using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameMangementSystem.Models
{
    /// <summary>
    /// model for users
    /// </summary>
    public class Users
    {
        public int ID { get; set; }
        //any number of - A-Z a-z _@&! or any digit
        [RegularExpression(@"[\-A-Za-z_@&!\d]*")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Username { get; set; }
        //any number of - A-Z a-z _@&! or any digit
        [RegularExpression(@"[\-A-Za-z_@&!\d]*")]
        //max length 255 min 5
        [StringLength(255, MinimumLength = 5)]
        [Required]
        public string Password { get; set; }
    }
}
