using ReactWithASP.Server.Models.DTOs;
using ReactyWithASP.Server.Models.DTOs;

namespace ReactyWithASP.Server.Services;

public interface IAuthService
{
    Task<(int, string)> Registration(RegistrationDto model);
    Task<(int, AuthDto)> Login(LoginDto model, HttpContext httpContext);
    AuthDto CheckSession(HttpContext httpContext);
    Task Logout(HttpContext httpContext);
}
