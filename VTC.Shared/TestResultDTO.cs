namespace VTC.Shared;

public class TestResultDTO
{
    public DateTime Timestamp { get; set; }
    public int Rotation { get; set; }
    public double StressLevel { get; set; }
    public double Temperature { get; set; }

    public TestResultDTO(DateTime timestamp, int rotation, double stressLevel, double temperature)
    {
        Timestamp = timestamp;
        Rotation = rotation;
        StressLevel = stressLevel;
        Temperature = temperature;
    }
}