using Prot.Domain.Entities.Users;

namespace Prot.Service.Interfaces.Tokens;

public interface ITokenRepository
{
    string CreateToken(User user);
}

