using VestasTestChallenge.Classes;

namespace VestasTestChallenge.Interfaces;

public interface ITestSimulator
{
    Task<List<TestResult>> StartTest(List<TestStep> steps);
}