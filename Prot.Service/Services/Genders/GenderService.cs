using Microsoft.EntityFrameworkCore;
using Prot.Domain.Configurations;
using Prot.Domain.Dto.Genders;
using Prot.Domain.Entities.Genders;
using Prot.Domain.Interface;
using Prot.Domain.Models.Genders;
using Prot.Service.Exceptions;
using Prot.Service.Extentions;
using Prot.Service.Interfaces.Genders;
using System.Linq.Expressions;
using Telegram.Bot.Types;

namespace Prot.Service.Services.Genders;

internal sealed class GenderService : IGenderRepository
{
    private readonly IGenericRepository<Gender> _genderRepository;

    public GenderService(IGenericRepository<Gender> genderRepository)
    {
        _genderRepository = genderRepository;
    }

    public async ValueTask<GenderModel> CreateAsync(GenderDto genderDto)
    {

        var addGender = new Gender
        {
            Title = genderDto.Title,
           
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
           
        };
        var createdGender = await _genderRepository.CreateAsync(addGender);
        await _genderRepository.SaveChangesAsync();
        return new GenderModel().MapFromEntity(createdGender);
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        var findGender = await _genderRepository.GetAsync(p => p.Id == id);
        if (findGender is null)
        {
            throw new ProtException(404, "gender_not_found");
        }
        await _genderRepository.DeleteAsync(id);
        await _genderRepository.SaveChangesAsync();
        return true;
    }

    public async ValueTask<IEnumerable<GenderModel>> GetAll(PaginationParams @params, Expression<Func<Gender, bool>> expression = null)
    {
        var genders = _genderRepository.GetAll(expression: expression, isTracking: false);
        var gendersList = await genders.ToPagedList(@params).ToListAsync();
        return gendersList.Select(e => new GenderModel().MapFromEntity(e)).ToList();
    }

    public async ValueTask<GenderModel> GetAsync(Expression<Func<Gender, bool>> expression)
    {
        var gender = await _genderRepository.GetAsync(expression, false);
        if (gender is null)
            throw new ProtException(404, "gender_not_found");
        return new GenderModel().MapFromEntity(gender);
    }

    public async ValueTask<GenderModel> UpdateAsync(int id, GenderDto genderDto)
    {
        var existingGender = await _genderRepository.GetAsync(p => p.Id == id) ?? throw new ProtException(404, "gender_not_found");

        if (genderDto.Title != null)
        {
            if (genderDto.Title.UZ != null)
            {
                existingGender.Title.UZ = genderDto.Title.UZ;
            }
            if (genderDto.Title.RU != null)
            {
                existingGender.Title.RU = genderDto.Title.RU;
            }
          
        }
        existingGender.UpdatedAt = DateTime.UtcNow;

        await _genderRepository.SaveChangesAsync();
        return new GenderModel().MapFromEntity(existingGender);
    }
}
