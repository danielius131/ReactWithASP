﻿using ReactyWithAsp.Server.Models.DTOs;

namespace ReactWithASP.Server.Services;

public interface IAuthService
{
    Task<(int, string)> Registration(RegistrationDto model);
    Task<(int, AuthDto)> Login(LoginDto model, HttpContext httpContext);
    AuthDto CheckSession(HttpContext httpContext);
    Task Logout(HttpContext httpContext);
}
