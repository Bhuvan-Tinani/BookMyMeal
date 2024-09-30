using BookMyMeal.Models.Domain;
using BookMyMeal.Models.DTO;
using BookMyMeal.Respositaries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo departmentRepo;

        public DepartmentController(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }

        //POST {apibaseURL}/api/department
        [HttpPost]
        public async Task<IActionResult> createDepartment([FromBody]CreateDepartmentRequest request)
        {
            var department = new Department()
            {
                Id = new Guid(),
                DeptName=request.departmentName,
            };
            department=await departmentRepo.createNewDepartment(department);
            var response = new DepartmentDTO()
            {
                Id = department.Id,
                DeptName = request.departmentName,
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> getAllDepartment()
        {
            var deparments=await departmentRepo.getAllDepartments();
            var response = new List<DepartmentDTO>();
            foreach(var department in deparments)
            {
                response.Add(new DepartmentDTO()
                {
                    Id = department.Id,
                    DeptName = department.DeptName
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getDepartmentById([FromRoute] Guid id)
        {
            var department= await departmentRepo.getDepartmentById(id);
            if(department is null)
            {
                return NotFound();
            }
            var response = new DepartmentDTO()
            {
                Id = department.Id,
                DeptName = department.DeptName,
            };
            return Ok(response);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> deleteDepartmentById([FromRoute] Guid id)
        {
            var department=await departmentRepo.deleteDepartmentById(id);
            if (department is null)
            {
                return NotFound();
            }
            var response = new DepartmentDTO()
            {
                Id = department.Id,
                DeptName = department.DeptName,
            };
            return Ok(response);
        }
    }
}
