using DndTaskDb.Models;
using Microsoft.EntityFrameworkCore;

namespace DndTaskDb.Db;

public class AppDataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=dnd;Integrated Security=True");
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(config => config.AddConsole()));
    }
    
    public DbSet<Character> Characters { get; set; }
}