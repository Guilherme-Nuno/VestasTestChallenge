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
    public async Task<List<TestResult>> StartTest(List<TestStep> steps)
    {
        ArgumentNullException.ThrowIfNull(steps);
        
        // Add test to database
        var testId = Guid.NewGuid();
        await _dbConnection.AddTestAsync("", testId);

        foreach (var step in steps)
        {
            // Add test sequence to database
            await _dbConnection.AddTestStepAsync(step.RotationSpeed, step.Duration, testId);
            SimulateStep(step, testId);
        }
        
        return _results;
    }

    private async void SimulateStep(TestStep step, Guid testId)
    {
        
        for (var i = 0; i < step.Duration; i++)
        {
            var random = new Random().NextDouble() * 100 - 50;
            
            var timeStamp = DateTime.UtcNow.AddSeconds(i);
            var rotationSpeed = step.RotationSpeed + Convert.ToInt32(Math.Round(random));
            var stressLevel = CalculateStressLevel(rotationSpeed);
            var temperature = CalculateTemperature(rotationSpeed);
            
            _results.Add(new TestResult(timeStamp, rotationSpeed, stressLevel, temperature));
            
            // Add result to database
            await _dbConnection.AddTestResultAsync(temperature, stressLevel, rotationSpeed, testId);
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