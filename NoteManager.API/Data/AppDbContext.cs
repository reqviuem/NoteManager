using Microsoft.EntityFrameworkCore;
using NoteManager.Models;

namespace NoteManager.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Note> Notes => Set<Note>();
}