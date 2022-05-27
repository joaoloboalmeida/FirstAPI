using Game.Models;
using Microsoft.EntityFrameworkCore;

namespace Game.Data
{
    public class GameDbContext : DbContext
    {
        public DbSet<GameModel> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db; Cache=Shared");
    }
}