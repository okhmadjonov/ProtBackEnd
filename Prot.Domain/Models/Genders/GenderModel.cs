using Prot.Domain.Entities.Genders;
using Prot.Domain.Entities.Multilanguage;
using Prot.Domain.Models.Users;

namespace Prot.Domain.Models.Genders;

public class GenderModel
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Language Title { get; set; }

    public virtual GenderModel MapFromEntity(Gender entity)
    {
        Id = entity.Id;
        CreatedAt = entity.CreatedAt;
        UpdatedAt = entity.UpdatedAt == DateTime.MinValue ? null : entity.UpdatedAt;
        Title = entity.Title;
       
        return this;
    }
}
