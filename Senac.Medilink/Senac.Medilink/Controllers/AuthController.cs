﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senac.Medilink.Data.Dto.Request.Login;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Controllers;

[AllowAnonymous]
public class AuthController : Controller
{
    private readonly ILoginService _loginService;
    private readonly IUserService _userService;

    public AuthController(ILoginService loginService, IUserService userService)
    {
        _loginService = loginService;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        if (Request.Headers.ContainsKey("Authorization"))
            return RedirectToAction("Index", "Home");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var token = await _loginService.LoginAsync(request, cancellationToken); 

            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(1)
            }); 

            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            return ViewBag(ex.Message);
        }
    }

    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _userService.RegisterAsync(request, cancellationToken);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return ViewBag(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        Response.Cookies.Delete("jwt");
        return RedirectToAction("Index");
    }
}
