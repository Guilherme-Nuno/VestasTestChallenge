using VestasTestChallenge.Classes;
using VestasTestChallenge.Interfaces;
using VTC.Shared;

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
    public async Task<List<TestResult>> StartTest(List<TestSequenceDTO> steps, Guid testId)
    {
        ArgumentNullException.ThrowIfNull(steps);
        
        // Add test to database
        await _dbConnection.AddTestAsync("", testId);

        foreach (var step in steps)
        {
            // Convert TestSequenceDTO to TestStep
            TestStep testStep = new TestStep(step, testId);
            
            // Add test sequence to database
            await _dbConnection.AddTestStepAsync(testStep.RotationSpeed, testStep.Duration, testId);
            SimulateStep(testStep, testId);
        }
        
        // Add EndTime to test on Database
        await _dbConnection.UpdateTestEndTimeAsync(testId);
        
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
        var random = new Random().NextDouble();
        
        return random * 100;
    }

    private double CalculateTemperature(int rotationSpeed)
    {
        var random = new Random().NextDouble();
        
        return random * 100;  
    }
}