using Prot.Domain.Entities.Users;

namespace Prot.Domain.Entities.Genders;

public class GenderConnectUser
{
    public Gender Gender { get; set; }
    public int GenderId { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }
}
