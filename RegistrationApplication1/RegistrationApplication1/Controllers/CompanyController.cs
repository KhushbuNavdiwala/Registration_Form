using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApplication1.Data;
using RegistrationApplication1.Models.Domain;
using RegistrationApplication1.Models;

namespace RegistrationApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //API controller 
    public class CompanyController : ControllerBase
    {
        
        private readonly ApplicationDbContext dbContext;
        public CompanyController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       

        [HttpPost] 
        public IActionResult AddCompany(AddCompanyDTO request)
        {
            var domainModelCompany = new Company
            {
                CompanyId = Guid.NewGuid(),
                CompanyName = request.CompanyName,
                Industry = request.Industry,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
               

            };
            dbContext.Companies.Add(domainModelCompany);
            dbContext.SaveChanges();

            return Ok(domainModelCompany);
        }
    }
}