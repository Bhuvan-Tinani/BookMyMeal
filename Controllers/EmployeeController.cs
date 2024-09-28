using BookMyMeal.Models.DTO;
using BookMyMeal.Respositaries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        //{apibase url}= localhost:7200/api/Employee/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> employeeLogin([FromBody]EmployeeLoginRequest request)
        {
            var reponse=await employeeRepo.empLogin(request.email, request.password);

            return Ok(reponse);
        }
    }
}
