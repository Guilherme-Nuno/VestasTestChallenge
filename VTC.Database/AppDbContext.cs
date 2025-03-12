using Microsoft.EntityFrameworkCore;
using VTC.Database.Models;

namespace VTC.Database;

public class AppDbContext : DbContext
{
    public DbSet<TestStep> TestSteps { get; set; }
    public DbSet<TestResult> TestResults { get; set; }
    public DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=vtc_data.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>()
            .HasMany(t => t.TestSteps)
            .WithOne()
            .HasForeignKey(ts => ts.TestId);
        
        modelBuilder.Entity<Test>()
            .HasMany(t => t.TestResults)
            .WithOne()
            .HasForeignKey(r => r.TestId);
    }
}