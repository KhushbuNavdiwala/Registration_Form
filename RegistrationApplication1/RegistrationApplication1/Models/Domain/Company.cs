namespace RegistrationApplication1.Models.Domain;
public class Company
{

    public Guid CompanyId { get; set; }
    public required string CompanyName { get; set; }
    public required string Industry { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
   


}

