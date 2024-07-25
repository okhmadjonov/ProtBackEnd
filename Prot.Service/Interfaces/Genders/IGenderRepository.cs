using Prot.Domain.Configurations;
using Prot.Domain.Dto.Genders;
using Prot.Domain.Dto.Users;
using Prot.Domain.Entities.Genders;
using Prot.Domain.Models.Genders;
using Prot.Domain.Models.Users;
using System.Linq.Expressions;

namespace Prot.Service.Interfaces.Genders;

public interface IGenderRepository
{
    ValueTask<IEnumerable<GenderModel>> GetAll(PaginationParams @params, Expression<Func<Gender, bool>> expression = null);
    ValueTask<GenderModel> GetAsync(Expression<Func<Gender, bool>> expression);
    ValueTask<GenderModel> CreateAsync(GenderDto genderDto);
    ValueTask<bool> DeleteAsync(int id);
    ValueTask<GenderModel> UpdateAsync(int id, GenderDto genderDto);
}
