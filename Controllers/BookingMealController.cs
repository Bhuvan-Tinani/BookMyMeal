using BookMyMeal.Models.Domain;
using BookMyMeal.Models.DTO;
using BookMyMeal.Respositaries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingMealController : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;
        private readonly IMealMenuRepo mealMenuRepo;
        private readonly IBookingMealRepo bookingMealRepo;

        public BookingMealController(IEmployeeRepo employeeRepo,IMealMenuRepo mealMenuRepo,
            IBookingMealRepo bookingMealRepo)
        {
            this.employeeRepo = employeeRepo;
            this.mealMenuRepo = mealMenuRepo;
            this.bookingMealRepo = bookingMealRepo;
        }

        [HttpPost]
        public async Task<IActionResult> bookMealForEmp([FromBody]BookMealRequest request)
        {
            var bookMeal = new BookMeal()
            {
                id = new Guid(),
                bookingDate = DateTime.Now,
                Note = request.Note,
                payment = request.payment,
                numberOfMeal = request.numberOfMeal,
                Meals = new List<Meal>()
            };
            var emp = await employeeRepo.getEmpByIdAsync(request.empId);
            if(emp is null)
            {
                return NotFound();
            }
            bookMeal.employee = emp;
            foreach(var mealid in request.mealIds)
            {
                var existingMeal=await mealMenuRepo.getMealById(mealid);
                if(existingMeal is not null)
                {
                    bookMeal.Meals.Add(existingMeal);
                }
            }
            bookMeal=await bookingMealRepo.createBookMealAsync(bookMeal);
            var response = new BookMealDTO()
            {
                id = bookMeal.id,
                bookingDate = bookMeal.bookingDate,
                Note = bookMeal.Note,
                payment = bookMeal.payment,
                numberOfMeal = bookMeal.numberOfMeal,
                employee = new EmployeeDTO()
                {
                    Id = bookMeal.employee.Id,
                    FirstName = bookMeal.employee.FirstName,
                    LastName = bookMeal.employee.LastName,
                    Phone = bookMeal.employee.Phone,
                    Email = bookMeal.employee.Email,
                    Password = bookMeal.employee.Password,
                    Department = new DepartmentDTO()
                    {
                        Id = bookMeal.employee.Department.Id,
                        DeptName = bookMeal.employee.Department.DeptName
                    },
                },
                meals = bookMeal.Meals.Select(meal => new MealDTO()
                {
                    Id = meal.Id,
                    name = meal.name,
                    day = meal.day,
                    description = meal.description,
                    price = meal.price,
                    mealType=new MealTypeDTO()
                    {
                        id=meal.mealType.id,
                        type=meal.mealType.type
                    },
                    Menus = meal.Menus.Select(menu =>new MenuDTO()
                    {
                        id=menu.id,
                        name=menu.name,
                    }).ToList(),
                }).ToList(),
            };
            return Ok(response);
        }
    }
}
