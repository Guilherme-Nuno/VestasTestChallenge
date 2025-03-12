namespace VTC.Database.Models;

public class TestStep
{
    public Guid Id { get; set; }
    public int SetPoint { get; set; }
    public int Duration { get; set; }
    
    public Guid TestId { get; set; }
    public Test Test { get; set; } = null!;
}