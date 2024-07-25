using Prot.Domain.Entities.Users;

namespace Prot.Domain.Models.Users;

public class UserModel
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string  Phonenumber { get; set; }
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public string Surename { get; set; }
    public int Age { get; set; }
    public string Password { get; set; }
    public double Balance { get; set; }
    public int GenderId { get; set; }
    public virtual UserModel MapFromEntity(User entity, int genderId)
    {
        Id = entity.Id;
        CreatedAt = entity.CreatedAt;
        UpdatedAt = entity.UpdatedAt == DateTime.MinValue ? null : entity.UpdatedAt;
        Name = entity.Name;
        Surename = entity.Surename;
        Phonenumber = entity.Phonenumber;
        Password = entity.Password;
        GenderId = genderId;
        return this;
    }
}
