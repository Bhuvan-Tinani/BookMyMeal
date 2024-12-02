using BookMyMeal.Models.Domain;
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
        private readonly IDepartmentRepo departmentRepo;

        public EmployeeController(IEmployeeRepo employeeRepo, IDepartmentRepo departmentRepo)
        {
            this.employeeRepo = employeeRepo;
            this.departmentRepo = departmentRepo;
        }


        //POST {baseurl}/api/Employee
        [HttpPost]
        public async Task<IActionResult> createEmployee([FromBody] CreateEmployeeRequest request)
        {
            Department department = await departmentRepo.getDepartmentById(request.deptId);
            if(department is not null)
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
                employee=await employeeRepo.createEmployee(employee);
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
            return NotFound();
        }

        //{apibase url}= localhost:7200/api/Employee/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> employeeLogin([FromBody]EmployeeLoginRequest request)
        {
            var reponse=await employeeRepo.empLogin(request.email, request.password);

            return Ok(reponse);
        }

        //GETallemployee
        [HttpGet]
        public async Task<IActionResult> employeeLogin()
        {
            var employes=await employeeRepo.getAllEmployees();
            var response=new List<EmployeeDTO>();
            foreach(var employee in employes)
            {
                response.Add(new EmployeeDTO()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    Password = employee.Password,
                    Department = new DepartmentDTO()
                    {
                        DeptName = employee.Department.DeptName,
                        Id = employee.Department.Id
                    }
                });
            }
            return Ok(response);
        }

        //getEmpById
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getEmpByid([FromRoute] Guid id)
        {
            var employee = await employeeRepo.getEmpByIdAsync(id);
            if(employee is null)
            {
                return NotFound();
            }
            var response = new EmployeeDTO()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Phone = employee.Phone,
                Email = employee.Email,
                Password = employee.Password,
                Department = new DepartmentDTO()
                {
                    Id = employee.Department.Id,
                    DeptName = employee.Department.DeptName,
                }
            };
            return Ok(response);

        }
    }
}
