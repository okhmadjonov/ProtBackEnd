namespace Prot.Domain.Entities.TelegramCode;


public class VerificationCode
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Code { get; set; }
    public DateTime ExpirationTime { get; set; }
}

