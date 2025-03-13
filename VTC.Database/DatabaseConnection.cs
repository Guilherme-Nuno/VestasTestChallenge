using Microsoft.AspNetCore.SignalR;
using VTC.Database.Interfaces;
using VTC.Database.Models;
using VTC.Shared;

namespace VTC.Database;

public class DatabaseConnection : IDatabaseConnection
{
    private readonly AppDbContext _context;
    private readonly IHubContext<TestResultHub> _testResultHub;
    public DatabaseConnection(AppDbContext context,  IHubContext<TestResultHub> testResultHub)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _testResultHub = testResultHub ?? throw new ArgumentNullException(nameof(testResultHub));
    }

    public async Task SendTestResult(TestResultDTO testResult)
    {
        await _testResultHub.Clients.All.SendAsync("SendTestResult", testResult);
    }
    
    public async Task<Test> AddTestAsync(String name, Guid id)
    {
        var test = new Test
        {
            Name = name,
            Id = id,
            StartTime = DateTime.UtcNow,
            
            TestSteps = new List<TestStep>(), 
            TestResults = new List<TestResult>()
        };
        
        _context.Tests.Add(test);
        await _context.SaveChangesAsync();
        
        return test;
    }

    public async Task<Test> UpdateTestEndTimeAsync(Guid id)
    {
        var test = _context.Tests.SingleOrDefault(x => x.Id == id);
        
        ArgumentNullException.ThrowIfNull(test);
        
        test.EndTime = DateTime.UtcNow;
        _context.Tests.Update(test);
        await _context.SaveChangesAsync();
        
        return test;
    }

    public async Task<TestStep> AddTestStepAsync(int setPoint, int duration, Guid testId)
    {
        var step = new TestStep
        {
            Id = Guid.NewGuid(),
            Duration = duration,
            SetPoint = setPoint,
            TestId = testId
        };
        
        _context.TestSteps.Add(step);
        await _context.SaveChangesAsync();

        return step;
    }

    public async Task<TestResult> AddTestResultAsync(double temperature, double stressLevel, int rotation, Guid testId)
    {
        var result = new TestResult
        {
            Id = Guid.NewGuid(),
            Temperature = temperature,
            StressLevel = stressLevel,
            RotationSpeed = rotation,
            TestId = testId,
            TimeStamp = DateTime.UtcNow
        };
        
        _context.TestResults.Add(result);
        await _context.SaveChangesAsync();

        await SendTestResult(ConvertTestResultToDto(result));
        
        return result;
    }

    private TestResultDTO ConvertTestResultToDto(TestResult testResult)
    {
        return new TestResultDTO(testResult.TimeStamp, testResult.RotationSpeed, testResult.StressLevel,
            testResult.Temperature);
    }
}