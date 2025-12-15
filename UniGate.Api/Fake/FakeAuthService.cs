using UniGate.Core.Interfaces;

namespace UniGate.Api.Fakes;

public class FakeAuthService : IAuthService
{
    public Task<object> RegisterAsync(object dto)
    {
        return Task.FromResult<object>(new
        {
            Success = true,
            Message = "Fake register OK"
        });
    }
}
