using Microsoft.EntityFrameworkCore;
using VTC.Database.Models;

namespace VTC.Database;

public class AppDbContext : DbContext
{
    public DbSet<TestStep> TestSteps { get; set; }
    public DbSet<TestResult> TestResults { get; set; }
    public DbSet<Test> Tests { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO Fix path
        var path = "/Users/Gui/RiderProjects/VestasTestChallenge/VTC.Database/vtc_data.db";
        optionsBuilder.UseSqlite($"Data Source={path}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<TestStep>()
            .HasOne(ts => ts.Test)  
            .WithMany(t => t.TestSteps)  
            .HasForeignKey(ts => ts.TestId)  
            .OnDelete(DeleteBehavior.Cascade); 
        
        modelBuilder.Entity<TestResult>()
            .HasOne(tr => tr.Test)
            .WithMany(t => t.TestResults)
            .HasForeignKey(tr => tr.TestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}