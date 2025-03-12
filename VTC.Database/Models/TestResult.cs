namespace VTC.Database.Models;

public class TestResult
{
    public Guid Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public int RotationSpeed { get; set; }
    public double StressLevel { get; set; }
    public double Temperature { get; set; }
    
    public Guid TestId { get; set; } // Foreign key test ID
    public Test Test { get; set; } = null!;
}