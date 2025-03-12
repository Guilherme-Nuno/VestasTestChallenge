namespace VTC.Database.Models;

public class Test
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public ICollection<TestStep> TestSteps { get; set; } = new  List<TestStep>();
    public ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
}