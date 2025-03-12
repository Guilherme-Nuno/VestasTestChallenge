// See https://aka.ms/new-console-template for more information

using VestasTestChallenge;
using VestasTestChallenge.Classes;

using Microsoft.Extensions.DependencyInjection;
using VTC.Database.Interfaces;
using VTC.Database;

var serviceProvider = new ServiceCollection()
    .AddScoped<IDatabaseConnection, DatabaseConnection>()
    .BuildServiceProvider();

var databaseConnection = serviceProvider.GetService<IDatabaseConnection>();
    
var testSteps = new List<TestStep>();
var testId = Guid.NewGuid();

testSteps.Add(new TestStep(testId, new Guid(), 1500, 15));
testSteps.Add(new TestStep(testId, new Guid(), 2500, 7));

var testSimulator = new TestSimulator(databaseConnection);
var results = testSimulator.StartTest(testSteps);


foreach (var result in results)
{
    Console.WriteLine($"TimeStamp: {result.TimeStamp}, RotationSpeed: {result.RotationSpeed}, StressLevel: {result.StressLevel}, Temperature: {result.Temperature}");    
}