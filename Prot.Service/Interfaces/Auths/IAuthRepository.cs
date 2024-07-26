using Prot.Domain.Dto.Users;
using Prot.Domain.Models.Users;

namespace Prot.Service.Interfaces.Auths;
public interface IAuthRepository
{
    ValueTask<UserModel> Registration(UserForCreationDto user);
    Task<string> Login(LoginDto loginDto);
}
