using Prot.Domain.Commons;
using Prot.Domain.Entities.Users;

namespace Prot.Domain.Entities.Roles;

public class UserRole : Auditable
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}