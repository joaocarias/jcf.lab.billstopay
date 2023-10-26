using jcf.billstopay.api.Models;

namespace jcf.billstopay.api.Services.IServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
