using Microsoft.AspNetCore.Identity.Data;
using Senac.Medilink.Data.Dto.Request.Login;

namespace Senac.Medilink.Services.Interface;

public interface IUserService
{
    Task RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken = default);
}
