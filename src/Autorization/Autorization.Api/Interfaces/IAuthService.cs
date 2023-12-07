using Autorization.Api.Models;

namespace Autorization.Api.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(Login login);
    }
}