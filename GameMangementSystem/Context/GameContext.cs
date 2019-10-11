using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameMangementSystem.Context
{
    /// <summary>
    /// Databse context from application
    /// </summary>
    public class GameContext : DbContext
    {
        public GameContext (DbContextOptions<GameContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// DB set for the game model
        /// </summary>
        public DbSet<GameMangementSystem.Models.Game> Game { get; set; }
        /// <summary>
        /// db set for the users model
        /// </summary>
        public DbSet<GameMangementSystem.Models.Users> Users { get; set; }
    }
}
