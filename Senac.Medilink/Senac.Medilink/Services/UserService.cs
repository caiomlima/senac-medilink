using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Senac.Medilink.Data;
using Senac.Medilink.Data.Dto.Request.Login;
using Senac.Medilink.Data.Entity.User;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Services;

public class UserService : IUserService
{
    private readonly DatabaseContext _databaseContext;
    private readonly IPasswordHasher<RegisterUserRequest> _passwordHasher;

    public UserService(
        DatabaseContext databaseContext,
        IPasswordHasher<RegisterUserRequest> passwordHasher)
    {
        _databaseContext = databaseContext;
        _passwordHasher = passwordHasher;
    }

    public async Task RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken = default)
    {
        var existingUser = await _databaseContext.Users
            .AsNoTracking()
            .IgnoreQueryFilters()
            .IgnoreAutoIncludes()
            .Where(u => u.Email == request.Email)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingUser != null)
            throw new Exception("Usuário já existente com email informado");

        var userPassword = _passwordHasher.HashPassword(request, request.Password);
        var user = new User(request.Email, userPassword, Common.UserType.Patient); // UserType fixo por agora

        //if (request.UserType is Common.UserType.Professional)
        //    user.AddProfessional(request.Name, request.Document);
        //else if (request.UserType is Common.UserType.Patient)
            user.AddPatient(request.Name, request.Document); // UserType fixo por agora

        _databaseContext.Add(user);
        await _databaseContext.SaveChangesAsync(cancellationToken);
    }
}
