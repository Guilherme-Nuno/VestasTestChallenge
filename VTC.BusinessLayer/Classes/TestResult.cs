namespace VestasTestChallenge.Classes;

public class TestResult
{
    public DateTime TimeStamp { get; set; }
    public int RotationSpeed { get; set; }
    public double StressLevel { get; set; }
    public double Temperature { get; set; }
    
    // Constructor
    public TestResult(DateTime timeStamp, int  rotationSpeed, double stressLevel, double temperature)
    {
        TimeStamp = timeStamp;
        RotationSpeed = rotationSpeed;
        StressLevel = stressLevel;
        Temperature = temperature;
    }
}