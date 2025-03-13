using Microsoft.AspNetCore.SignalR;

namespace VTC.Shared;

public class TestResultHub : Hub
{
    public async Task SendTestResult(TestResultDTO testResult)
    {
        await Clients.All.SendAsync("SendTestResult", testResult);
    }
}