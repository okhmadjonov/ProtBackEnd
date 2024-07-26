using Prot.Domain.Dto.Users;
using Prot.Domain.Entities.Users;
using Prot.Domain.Interface;
using Prot.Domain.Models.Users;
using Prot.Service.Exceptions;
using Prot.Service.Interfaces.Auths;
using Prot.Service.Interfaces.Tokens;
using Prot.Infrastructure.Extentions;

namespace Prot.Service.Services.Auths;



internal sealed class AuthService : IAuthRepository
{
    private readonly IGenericRepository<User> _genericRepository;
    private readonly ITokenRepository _tokenGenerator;

    public AuthService(IGenericRepository<User> genericRepository, ITokenRepository tokenGenerator)
    {
        _genericRepository = genericRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> Login(LoginDto loginDto)
    {
        if (loginDto.Phonenumber != null)
        {
            var user = await _genericRepository.GetAsync(u => u.Phonenumber == loginDto.Phonenumber);

            if (user != null)
            {
                bool verify = Verify(loginDto.Password, user.Password);

                if (verify)
                {
                    return _tokenGenerator.CreateToken(user);
                }
                else
                {
                    throw new ProtException(401, "incorrect_password");
                }
            }
            else
            {
                throw new ProtException(404, "user_not_found");
            }
        }
        throw new ProtException(404, "user_not_found");
    }

    public async ValueTask<UserModel> Registration(UserForCreationDto user)
    {
        var existingUser = await _genericRepository.GetAsync(u => u.Phonenumber == user.Phonenumber);

        if (existingUser == null)
        {
            string fileName = Path.Combine("images", Guid.NewGuid().ToString("N") + Path.GetExtension(user.ImageUrl.FileName));
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await user.ImageUrl.CopyToAsync(fileStream);
            }

            string passwordHash = user.Password.Encrypt();

            User newUser = new User
            {
                Phonenumber = user.Phonenumber,
                Name = user.Name,
                Surename = user.Surename,
                Age = user.Age,
                GenderId = user.GenderId,
                Password = passwordHash,
                ImageUrl = fileName,
                City = user.City,
                Balance = 0
            }; ;

            var registeredUser = await _genericRepository.CreateAsync(newUser);
            await _genericRepository.SaveChangesAsync();
            return new UserModel().MapFromEntity(registeredUser, user.GenderId);
        }
        else
        {
            throw new ProtException(401, "user_already_exist");
        }
    }
    public static bool Verify(string password, string hashedPassword)
    {
        string hashedInputPassword = password.Encrypt();
        return string.Equals(hashedInputPassword, hashedPassword);
    }
}


