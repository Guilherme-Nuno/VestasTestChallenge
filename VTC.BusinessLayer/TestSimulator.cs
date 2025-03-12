using VestasTestChallenge.Classes;
using VestasTestChallenge.Interfaces;

namespace VestasTestChallenge;

using VTC.Database.Interfaces;

public class TestSimulator : ITestSimulator
{
    private IDatabaseConnection _dbConnection;
    private List<TestResult> _results;

    public TestSimulator(IDatabaseConnection dbConnection)
    {
        _results = new List<TestResult>();
        _dbConnection =  dbConnection;
    }
    public List<TestResult> StartTest(List<TestStep> steps)
    {
        ArgumentNullException.ThrowIfNull(steps);

        foreach (var step in steps)
        {
            SimulateStep(step);
        }
        
        return _results;
    }

    private void SimulateStep(TestStep step)
    {
        
        for (var i = 0; i < step.Duration; i++)
        {
            var random = new Random().NextDouble() * 100;
            
            var timeStamp = DateTime.UtcNow.AddSeconds(i);
            var rotationSpeed = step.RotationSpeed + random;
            var stressLevel = CalculateStressLevel(Convert.ToInt32(Math.Round(rotationSpeed)));
            var temperature = CalculateTemperature(Convert.ToInt32(Math.Round(rotationSpeed)));

            _results.Add(new TestResult(timeStamp, step.RotationSpeed, stressLevel, temperature));
        }
    }

    private double CalculateStressLevel(int rotationSpeed)
    {
        var random = new Random().NextDouble() / 8;
        
        return rotationSpeed * random / 100;
    }

    private double CalculateTemperature(int rotationSpeed)
    {
        var random = new Random().NextDouble() / 8;
        
        return rotationSpeed * random / 250;  
    }
}