using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Prot.Domain.Dto.Users;

public class UserForCreationDto
{


    [Required]
    public string Phonenumber { get; set; }

    [Required]
    public IFormFile ImageUrl { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surename { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public int GenderId { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Password { get; set; }
}
