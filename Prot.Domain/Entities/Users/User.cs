using Prot.Domain.Commons;

namespace Prot.Domain.Entities.Users;

public class User : Auditable
{
    public string Phonenumber { get; set; }
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public string Surename { get; set; }
    public int Age { get; set; }
    public int GenderId { get; set; }
    public string City { get; set; }
    public string Password { get; set; }
    
    public decimal Balance { get; set; }

}
