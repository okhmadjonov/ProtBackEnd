using Prot.Domain.Commons;
using Prot.Domain.Entities.Multilanguage;

namespace Prot.Domain.Entities.Genders;

public class Gender : Auditable
{
    public Language Title;
    public List<GenderConnectUser> Users { get; set;}
}
