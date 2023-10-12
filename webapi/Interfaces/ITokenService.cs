using webapi.Models;

namespace webapi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
