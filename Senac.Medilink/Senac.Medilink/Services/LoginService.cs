using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Senac.Medilink.Data;
using Senac.Medilink.Data.Dto.Request.Login;
using Senac.Medilink.Data.Entity.User;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Services
{
    public class LoginService : ILoginService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly TokenService _tokenService;

        public LoginService(
            DatabaseContext databaseContext,
            IPasswordHasher<User> passwordHasher,
            TokenService tokenService)
        {
            _databaseContext = databaseContext;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(LoginUserRequest loginRequest, CancellationToken cancellationToken = default)
        {
            var user = await _databaseContext.Users
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .IgnoreQueryFilters()
                .Where(x => x.Email == loginRequest.Email)
                .FirstOrDefaultAsync(cancellationToken);

            if (user is null)
                throw new Exception("Usuário não encontrado");

            if (_passwordHasher.VerifyHashedPassword(user, user.Password, loginRequest.Password) is PasswordVerificationResult.Failed)
                throw new Exception("Senha incorreta");
            
            return _tokenService.GenerateToken(user);
        }
    }
}
