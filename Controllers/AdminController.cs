using BookMyMeal.Models.Domain;
using BookMyMeal.Models.DTO;
using BookMyMeal.Respositaries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookMyMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepo adminRepo;

        public AdminController(IAdminRepo adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        [HttpPost]
        public async Task<IActionResult> AdminCreate([FromBody]AdminCreateRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.username) || string.IsNullOrWhiteSpace(request.password))
            {
                // Return 400 Bad Request if input validation fails
                return BadRequest("Invalid admin data. Username and password are required.");
            }

            try
            {
                // Create new admin
                var admin = new Admin()
                {
                    Id = Guid.NewGuid(),
                    Username = request.username,
                    Password = request.password,
                };

                // Save the admin to the repository
                admin=await adminRepo.createAdmin(admin);

                // Prepare the response DTO
                var response = new AdminDTO()
                {
                    Id = admin.Id,
                    Username = admin.Username,
                    Password = admin.Password
                };

                // Return 201 Created with the newly created admin data
                return Ok(response);
            }
            catch (Exception ex)
            {
                
                // Return 500 Internal Server Error if an unexpected error occurs
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the admin. Please try again later.");
            }
        }

    }
}
