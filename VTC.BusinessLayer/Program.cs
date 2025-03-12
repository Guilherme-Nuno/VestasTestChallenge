// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using VestasTestChallenge;
using VestasTestChallenge.Classes;

using Microsoft.Extensions.DependencyInjection;
using VTC.Database.Interfaces;
using VTC.Database;

var serviceProvider = new ServiceCollection()
    .AddDbContext<AppDbContext>()
    .AddScoped<IDatabaseConnection, DatabaseConnection>()
    .BuildServiceProvider();

var databaseConnection = serviceProvider.GetService<IDatabaseConnection>();
    
var testSteps = new List<TestStep>();
var testId = Guid.NewGuid();

testSteps.Add(new TestStep(testId, Guid.NewGuid(), 1500, 15));
testSteps.Add(new TestStep(testId, Guid.NewGuid(), 2500, 7));


var testSimulator = new TestSimulator(databaseConnection);
var results = await testSimulator.StartTest(testSteps);


foreach (var result in results)
{
    Console.WriteLine($"TimeStamp: {result.TimeStamp}, RotationSpeed: {result.RotationSpeed}, StressLevel: {result.StressLevel}, Temperature: {result.Temperature}");    
}