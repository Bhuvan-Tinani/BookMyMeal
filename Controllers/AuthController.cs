using BookMyMeal.Models.Domain;
using BookMyMeal.Models.DTO;
using BookMyMeal.Respositaries.Impemention;
using BookMyMeal.Respositaries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepo tokenRepo;
        private readonly IEmployeeRepo employeeRepo;
        private readonly IAdminRepo adminRepo;
        private readonly IDepartmentRepo departmentRepo;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepo tokenRepo, IEmployeeRepo employeeRepo, IAdminRepo adminRepo, IDepartmentRepo departmentRepo)
        {
            this.userManager = userManager;
            this.tokenRepo = tokenRepo;
            this.employeeRepo = employeeRepo;
            this.adminRepo = adminRepo;
            this.departmentRepo = departmentRepo;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var identityUser = await userManager.FindByEmailAsync(request.email);
            if (identityUser is not null)
            {
                //check password
                var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, request.password);
                
                if (checkPasswordResult)
                {
                    // Get user roles
                    var roles = await userManager.GetRolesAsync(identityUser);

                    // Check if the required role is present in user's roles
                    if (!roles.Contains(request.role))
                    {
                        ModelState.AddModelError("", "User does not have the required role.");
                        return ValidationProblem(ModelState);
                    }
                    // Create token and prepare response
                    var jwtToken = tokenRepo.createJwtToken(identityUser, roles.ToList());
                    var response = new LoginResponseDTO()
                    {
                        Email = request.email,
                        Roles = roles.ToList(),
                        Token = jwtToken
                    };
                    if (request.role.Equals("admin"))
                    {
                        var userId=await adminRepo.getAdminId(request.email);
                        response.userId = (Guid)userId;
                    }
                    else
                    {
                        var userId = await employeeRepo.getEmpId(request.email);
                        response.userId = (Guid)userId;
                    }
                    return Ok(response);
                }

            }
            ModelState.AddModelError("", "Email or password incorrect");
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> register([FromBody] CreateEmployeeRequest request)
        {
            Department department = await departmentRepo.getDepartmentById(request.deptId);
            if (department is not null)
            {
                var employee = new Employee()
                {
                    Id = new Guid(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Phone = request.Phone,
                    Email = request.Email,
                    Password = request.Password,
                    Department = department
                };
                var user = new IdentityUser
                {
                    UserName = request.Email?.Trim(),
                    Email = request.Email?.Trim(),
                };
                var identityResult = await userManager.CreateAsync(user, request.Password);
                if (identityResult.Succeeded)
                {
                    //add role to user(Reader)
                    identityResult = await userManager.AddToRoleAsync(user, "employee");
                    if (identityResult.Succeeded)
                    {
                        employee = await employeeRepo.createEmployee(employee);
                        var dept = new DepartmentDTO()
                        {
                            Id = employee.Department.Id,
                            DeptName = employee.Department.DeptName,
                        };
                        var response = new EmployeeDTO()
                        {
                            Id = employee.Id,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Phone = employee.Phone,
                            Email = employee.Email,
                            Password = employee.Password,
                            Department = dept,
                        };
                        return Ok(response);
                    }
                    else
                    {
                        if (identityResult.Errors.Any())
                        {
                            foreach (var error in identityResult.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return ValidationProblem(ModelState);
            }
            return NotFound();
        }
    }
}
