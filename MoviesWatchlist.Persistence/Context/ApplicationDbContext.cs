using Microsoft.EntityFrameworkCore;
using MoviesWatchlist.Domain.Entities;

namespace MoviesWatchlist.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<WatchListItem> WatchListItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<WatchListItem>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.MovieId });
        });
    }
}