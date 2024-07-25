using Prot.Domain.Commons;

namespace Prot.Domain.Entities.Roles;


public class Role : Auditable
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public Role() { }
    public Role(string name)
    {
        Name = name;
    }
}

