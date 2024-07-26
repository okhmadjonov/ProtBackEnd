using Prot.Domain.Commons;

namespace Prot.Domain.Entities.Game;


public class VerificationCode: Auditable
{
   
    public string PhoneNumber { get; set; }
    public string Code { get; set; }
    public DateTime ExpirationTime { get; set; }
}

