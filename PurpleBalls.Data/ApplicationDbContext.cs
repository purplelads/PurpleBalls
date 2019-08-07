using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PurpleBalls.Data.Models;

namespace PurpleBalls.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerShirt> PlayerShirts { get; set; }
    }
}
