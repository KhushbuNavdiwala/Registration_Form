using RegistrationApplication1.Models;

namespace RegistrationApplication1.Models
{
    public class AddCompanyDTO
    {

        public required String CompanyName { get; set; }
        public required string Industry { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        

    }
}
