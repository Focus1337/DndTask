using DndTaskDb.Models;
using Microsoft.EntityFrameworkCore;

namespace DndTaskDb.Repository;

public class ApplicationContext : DbContext
{
    public DbSet<Character> Characters { get; set; } = null!;
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
}