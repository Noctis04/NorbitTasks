using System.ComponentModel.DataAnnotations;

namespace UserService.Domain.Entity;

public class User
{
    [Key]
    public long Id { get; set; }

    public string Login { get; set; } = "";

    public string Password { get; set; } = "";

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string EmailAddress { get; set; } = "";

}
