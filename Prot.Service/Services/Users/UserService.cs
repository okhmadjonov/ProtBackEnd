using Microsoft.EntityFrameworkCore;
using Prot.Domain.Configurations;
using Prot.Domain.Dto.Users;
using Prot.Domain.Entities.Users;
using Prot.Domain.Interface;
using Prot.Domain.Models.Users;
using Prot.Infrastructure.Extentions;
using Prot.Infrastructure.Repositories;
using Prot.Service.Exceptions;
using Prot.Service.Extentions;
using Prot.Service.Interfaces.Users;
using System.Linq.Expressions;

namespace Prot.Service.Services.Users;

internal sealed class UserService : IUserRepository
{
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository)
        => _userRepository = userRepository;

    public async ValueTask<UserModel> CreateAsync(UserForCreationDto user)
    {

        var existingUser = await _userRepository.GetAsync(u => u.Phonenumber == user.Phonenumber);

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
            }; 

            var registeredUser = await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveChangesAsync();
            return new UserModel().MapFromEntity(registeredUser, user.GenderId);
        }
        else
        {
            throw new ProtException(401, "user_already_exist");
        }
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        var findUser = await _userRepository.GetAsync(p => p.Id == id);
        if (findUser is null)
        {
            throw new ProtException(404, "user_not_found");
        }


        if (!string.IsNullOrEmpty(findUser.ImageUrl))
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", findUser.ImageUrl);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
      
        await _userRepository.DeleteAsync(id);
        await _userRepository.SaveChangesAsync();
        return true;
    }

    public async ValueTask<IEnumerable<UserModel>> GetAll(PaginationParams @params, Expression<Func<User, bool>> expression = null)
    {
        var users = _userRepository.GetAll(expression: expression, isTracking: false);
        var usersList = await users.ToPagedList(@params).ToListAsync();
        return usersList.Select(e => new UserModel().MapFromEntity(e, e.GenderId)).ToList();
    }

    public async ValueTask<UserModel> GetAsync(Expression<Func<User, bool>> expression)
    {
        var user = await _userRepository.GetAsync(expression);
        if (user is null)
            throw new ProtException(404, "user_not_found");

        return new UserModel().MapFromEntity(user, user.GenderId);
    }

    public async ValueTask<UserModel> UpdateAsync(int id, UserForCreationDto userForUpdateDTO)
    {
        var user = await _userRepository.GetAsync(u => u.Id == id);

        if (user is null)
            throw new ProtException(404, "user_not_found");

        if (userForUpdateDTO.Name != user.Name)
            user.Name = userForUpdateDTO.Name;

        if (userForUpdateDTO.Phonenumber != user.Phonenumber)
            user.Phonenumber = userForUpdateDTO.Phonenumber;

        if (userForUpdateDTO.Name != user.Name)
            user.Name = userForUpdateDTO.Name;

        if (userForUpdateDTO.Surename != user.Surename)
            user.Surename = userForUpdateDTO.Surename;

        if (userForUpdateDTO.Age != user.Age)
            user.Age = userForUpdateDTO.Age;

        if (userForUpdateDTO.GenderId != user.GenderId)
            user.GenderId = userForUpdateDTO.GenderId;

        if (!string.IsNullOrEmpty(userForUpdateDTO.Password))
            user.Password = userForUpdateDTO.Password.Encrypt();

        if (userForUpdateDTO.ImageUrl != null)
        {
            string fileName = Path.Combine("images", Guid.NewGuid().ToString("N") + Path.GetExtension(userForUpdateDTO.ImageUrl.FileName));
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await userForUpdateDTO.ImageUrl.CopyToAsync(fileStream);
            }

            // Update the user's ImageUrl property
            user.ImageUrl = fileName;
        }

        user.UpdatedAt = DateTime.UtcNow;
        await _userRepository.SaveChangesAsync();
        return new UserModel().MapFromEntity(user, user.GenderId);
    }


}

