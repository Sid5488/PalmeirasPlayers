using PalmeirasPlayers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Storage;

namespace PalmeirasPlayers.Data
{
    public class DbPlayerContext : DbContext
    {
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;User=root;Password=;Database=palmeirasplayers");
        }
        */

        public DbPlayerContext(DbContextOptions<DbPlayerContext> options) : base(options)
        {
            
        }

        public DbSet<Players> PlayerList { get; set; }
    }
}
