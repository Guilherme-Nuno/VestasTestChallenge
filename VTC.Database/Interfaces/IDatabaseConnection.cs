using VTC.Database.Models;

namespace VTC.Database.Interfaces;

public interface IDatabaseConnection
{
    Task<Test> AddTestAsync(String name, Guid id);
    Task<Test> UpdateTestEndTimeAsync(Guid id);
    Task<TestStep> AddTestStepAsync(int setPoint, int duration, Guid testId);
    Task<TestResult> AddTestResultAsync(double temperature, double stressLevel, int rotation,  Guid testId);
    
}