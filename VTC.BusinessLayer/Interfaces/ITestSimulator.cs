using VestasTestChallenge.Classes;
using VTC.Shared;

namespace VestasTestChallenge.Interfaces;

public interface ITestSimulator
{
    Task<List<TestResult>> StartTest(List<TestSequenceDTO> steps, Guid testId);
}