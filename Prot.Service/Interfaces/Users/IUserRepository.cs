using Prot.Domain.Configurations;
using Prot.Domain.Dto.Users;
using Prot.Domain.Entities.Users;
using Prot.Domain.Models.Users;
using System.Linq.Expressions;

namespace Prot.Service.Interfaces.Users;

public interface IUserRepository
{
    ValueTask<IEnumerable<UserModel>> GetAll(PaginationParams @params, Expression<Func<User, bool>> expression = null);
    ValueTask<UserModel> GetAsync(Expression<Func<User, bool>> expression);
    ValueTask<UserModel> CreateAsync(UserForCreationDto userForCreationDTO);
    ValueTask<bool> DeleteAsync(int id);
    ValueTask<UserModel> UpdateAsync(int id, UserForCreationDto userForUpdateDTO);
}
