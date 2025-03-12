namespace VTC.Database.Models;

public class Test
{
    public Test()
    {
        TestSteps = new List<TestStep>();
        TestResults = new List<TestResult>();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public required ICollection<TestStep> TestSteps { get; set; }
    public required ICollection<TestResult> TestResults { get; set; }
}