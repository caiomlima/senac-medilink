using Microsoft.AspNetCore.Identity.Data;
using Senac.Medilink.Data.Dto.Request.Login;

namespace Senac.Medilink.Services.Interface;

public interface ILoginService
{
    Task<string> LoginAsync(LoginUserRequest loginRequest, CancellationToken cancellationToken = default);
}
