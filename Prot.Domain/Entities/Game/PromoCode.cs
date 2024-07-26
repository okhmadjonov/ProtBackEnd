using Prot.Domain.Commons;

namespace Prot.Domain.Entities.Game;

public class PromoCode : Auditable
{
    public string Code { get; set; }
    public bool IsUsed { get; set; }
}
