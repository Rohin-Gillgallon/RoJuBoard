using Microsoft.EntityFrameworkCore;
using RoJu.Core.Models;

namespace RoJu.Api.Data;

public class RoJuDBContext : DbContext {
    public RoJuDBContext(DbContextOptions<RoJuDBContext> options) : base(options) {
    }

    public DbSet<TaskCard> Cards => Set<TaskCard>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<TaskCard>().HasData(
            new TaskCard { 
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Title = "Set up Docker", 
                Description = "Get the Postgres working",
                Status = "Done",
                Order = 1,
                LastEditedBy = "Rohin"
            },
            new TaskCard { 
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Title = "Build API", 
                Description = "Create the first Endpoint", 
                Status = "In Progress", 
                Order = 2, 
                LastEditedBy = "Rohin"
            }
        );
    }
}