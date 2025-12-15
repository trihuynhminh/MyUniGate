using UniGate.Core.Interfaces;

namespace UniGate.Api.Fakes;

public class FakeTestService : ITestService
{
    public Task<object> SubmitAsync(object dto)
    {
        return Task.FromResult<object>(new
        {
            Score = 80,
            Result = "Fake submit OK"
        });
    }

    public Task CreateQuestionAsync(object dto)
    {
        return Task.CompletedTask;
    }

    public Task UpdateQuestionAsync(object dto)
    {
        return Task.CompletedTask;
    }
}
