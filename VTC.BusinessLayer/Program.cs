// See https://aka.ms/new-console-template for more information

using VestasTestChallenge;
using VestasTestChallenge.Classes;

var testSteps = new List<TestStep>();
testSteps.Add(new TestStep(new Guid(), new Guid(), 1500, 15));

var testSimulator = new TestSimulator();
var results = testSimulator.StartTest(testSteps);


foreach (var result in results)
{
    Console.WriteLine($"TimeStamp: {result.TimeStamp}, RotationSpeed: {result.RotationSpeed}, StressLevel: {result.StressLevel}, Temperature: {result.Temperature}");    
}