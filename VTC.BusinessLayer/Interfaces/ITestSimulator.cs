using VestasTestChallenge.Classes;

namespace VestasTestChallenge.Interfaces;

public interface ITestSimulator
{
    List<TestResult> StartTest(List<TestStep> steps);
}