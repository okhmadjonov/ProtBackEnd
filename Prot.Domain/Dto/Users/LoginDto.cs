using System.ComponentModel.DataAnnotations;

namespace Prot.Domain.Dto.Users;


public class LoginDto
{
    [Required]
    public string Phonenumber { get; set; }

    [Required]
    public string Password { get; set; }
}
