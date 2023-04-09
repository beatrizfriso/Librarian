using Librarian.Domain.Entities.Base;

namespace Librarian.Domain;

public class User : Entity
{
    public string Name { get; set; }
    public string BirthDate { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public bool IsActivated { get; set; }
    public string Role { get; set; }
}