using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameMangementSystem.Context
{
    public class GameContext : DbContext
    {
        public GameContext (DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public DbSet<GameMangementSystem.Models.Game> Game { get; set; }
    }
}
