﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Senac.Medilink.Data;
using Senac.Medilink.Data.Dto.Request.Login;
using Senac.Medilink.Data.Entity.User;
using Senac.Medilink.Services;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Infrastructure;

public class DependenciesConfiguration
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options => options
            .UseMySql(
                configuration["MySqlConnectionString"], // Pega infos do appsettings.json - Mudar user e senha com base no seu banco e rodar um migration para criar tabelas
                new MySqlServerVersion(new Version(8, 0, 0)),
                options => options.CommandTimeout(20)));

        //// Para usar SQLite | Comentar o de cima caso queria usar esse
        //services.AddDbContext<DatabaseContext>(options =>
        //    options.UseSqlite(configuration.GetConnectionString("SQLiteConnectionString")));

        services.AddScoped<IPasswordHasher<RegisterUserRequest>, PasswordHasher<RegisterUserRequest>>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<IProfessionalService, ProfessionalService>();
        services.AddScoped<ISpecialtyService, SpecialtyService>();
        services.AddScoped<IUnitService, UnitService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IUserService, UserService>();
        services.AddSingleton<TokenService>();
    }
}
