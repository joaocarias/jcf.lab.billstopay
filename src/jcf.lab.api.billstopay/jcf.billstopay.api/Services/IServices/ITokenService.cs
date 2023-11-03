using jcf.billstopay.api.Models;
using System.Security.Claims;

namespace jcf.billstopay.api.Services.IServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        ClaimsIdentity GenerateClaims(User user);
    }
}
