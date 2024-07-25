using Prot.Domain.Entities.Multilanguage;
using System.ComponentModel.DataAnnotations;

namespace Prot.Domain.Dto.Genders;

public class GenderDto
{
    [Required]
    public Language Title { get; set; }
}
