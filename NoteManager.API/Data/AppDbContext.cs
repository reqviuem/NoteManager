using Microsoft.EntityFrameworkCore;
using NoteManager.Models;

namespace NoteManager.Data;

public class AppDbContext : DbContext
{
    public DbSet<Note> Notes => Set<Note>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("Note");

            entity.HasKey(n => n.Guid);

            entity.Property(n => n.Title).IsRequired();
            entity.Property(n => n.Content).IsRequired();
            entity.Property(n => n.CreatedAt);

            entity.HasData(
                new Note
                {
                    Guid = Guid.Parse("3f7c2d91-8b4e-4a6f-9c12-7d5e8a1b2c34"),
                    Title = "Note 1",
                    Content = "Welcome to the notes app.",
                    CreatedAt = new DateTime(2026, 1, 1, 9, 0, 0)
                },
                new Note
                {
                    Guid = Guid.Parse("a92d6f10-3b7a-4e85-b1c9-2f4d7a8e6c11"),
                    Title = "Note 2",
                    Content = "How are you doing today?",
                    CreatedAt = new DateTime(2026, 1, 2, 9, 0, 0)
                },
                new Note
                {
                    Guid = Guid.Parse("6c1e9a44-5f2b-4d73-8a90-1e2f3b4c5d66"),
                    Title = "Note 3",
                    Content = "Remember to review the API endpoints.",
                    CreatedAt = new DateTime(2026, 1, 3, 9, 0, 0)
                },
                new Note
                {
                    Guid = Guid.Parse("f4b82c17-9d6e-4f21-a7b3-8c0d1e2f9a55"),
                    Title = "Note 4",
                    Content = "Buy groceries after classes.",
                    CreatedAt = new DateTime(2026, 1, 4, 9, 0, 0)
                },
                new Note
                {
                    Guid = Guid.Parse("19a7d3e8-2c4f-4b61-96ad-5e7f8c1d2b90"),
                    Title = "Note 5",
                    Content = "Read about dependency injection in ASP.NET Core.",
                    CreatedAt = new DateTime(2026, 1, 5, 9, 0, 0)
                },
                new Note
                {
                    Guid = Guid.Parse("c8f14b62-7a3d-4e9c-b205-6d1f2a3b4c88"),
                    Title = "Note 6",
                    Content = "Prepare the database migration for the project.",
                    CreatedAt = new DateTime(2026, 1, 6, 9, 0, 0)
                },
                new Note
                {
                    Guid = Guid.Parse("72e5a9c1-4d8f-4b30-8e17-9a2c6f3d1b77"),
                    Title = "Note 7",
                    Content = "Finish the controller methods and test them.",
                    CreatedAt = new DateTime(2026, 1, 7, 9, 0, 0)
                }
            );
        });
    }
}