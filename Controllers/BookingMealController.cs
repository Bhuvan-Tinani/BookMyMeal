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
        public async Task<IActionResult> bookMealForEmp([FromBody] BookMealRequest request)
        {
            var bookMeal = new BookMeal
            {
                id = Guid.NewGuid(),
                bookingDate = DateTime.Now,
                Note = request.Note,
                payment = request.payment,
                Status = "booked",
                employee = await employeeRepo.getEmpByIdAsync(request.empId),
                BookedMealDetails = new List<BookedMealDetails>()
            };

            if (bookMeal.employee is null)
            {
                return NotFound("Employee not found.");
            }

            foreach (var mealDetail in request.MealBookingDetails)
            {
                var existingMeal = await mealMenuRepo.getMealById(mealDetail.MealId);
                if (existingMeal is not null)
                {
                    bookMeal.BookedMealDetails.Add(new BookedMealDetails
                    {
                        Id = Guid.NewGuid(),
                        BookMeal = bookMeal,
                        Meal = existingMeal,
                        NumberOfMeal = mealDetail.NumberOfMeal,
                        Date = mealDetail.Date
                    });
                }
            }

            bookMeal = await bookingMealRepo.createBookMealAsync(bookMeal);

            var response = new BookMealDTO
            {
                id = bookMeal.id,
                bookingDate = bookMeal.bookingDate,
                Note = bookMeal.Note,
                payment = bookMeal.payment,
                Status = bookMeal.Status,
                employee = new EmployeeDTO
                {
                    Id = bookMeal.employee.Id,
                    FirstName = bookMeal.employee.FirstName,
                    LastName = bookMeal.employee.LastName,
                    Phone = bookMeal.employee.Phone,
                    Email = bookMeal.employee.Email,
                    Password = bookMeal.employee.Password,
                    Department = new DepartmentDTO
                    {
                        Id = bookMeal.employee.Department.Id,
                        DeptName = bookMeal.employee.Department.DeptName
                    }
                },
                BookedMealDetails = bookMeal.BookedMealDetails.Select(bmd => new BookedMealDetailsDTO
                {
                    Id = bmd.Id,
                    Date = bmd.Date,
                    NumberOfMeal = bmd.NumberOfMeal,
                    Meal = new MealDTO
                    {
                        Id = bmd.Meal.Id,
                        name = bmd.Meal.name,
                        day = bmd.Meal.day,
                        description = bmd.Meal.description,
                        price = bmd.Meal.price,
                        mealType = new MealTypeDTO
                        {
                            id = bmd.Meal.mealType.id,
                            type = bmd.Meal.mealType.type
                        },
                        Menus = bmd.Meal.Menus.Select(menu => new MenuDTO
                        {
                            id = menu.id,
                            name = menu.name
                        }).ToList()
                    }
                }).ToList()
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> getAllBookMealRecord()
        {
            // Retrieve all booked meals using the repository method
            var bookedMeals = await bookingMealRepo.getBookMyMeal();

            var response = bookedMeals.Select(bookmeal => new BookMealDTO
            {
                id = bookmeal.id,
                bookingDate = bookmeal.bookingDate,
                Note = bookmeal.Note,
                payment = bookmeal.payment,
                Status = bookmeal.Status,
                employee = new EmployeeDTO
                {
                    Id = bookmeal.employee.Id,
                    FirstName = bookmeal.employee.FirstName,
                    LastName = bookmeal.employee.LastName,
                    Phone = bookmeal.employee.Phone,
                    Email = bookmeal.employee.Email,
                    Department = new DepartmentDTO
                    {
                        Id = bookmeal.employee.Department.Id,
                        DeptName = bookmeal.employee.Department.DeptName
                    }
                },
                BookedMealDetails = bookmeal.BookedMealDetails.Select(bmd => new BookedMealDetailsDTO
                {
                    Id = bmd.Id,
                    Date = bmd.Date,
                    NumberOfMeal = bmd.NumberOfMeal,
                    Meal = new MealDTO
                    {
                        Id = bmd.Meal.Id,
                        name = bmd.Meal.name,
                        description = bmd.Meal.description,
                        price = bmd.Meal.price,
                        day = bmd.Meal.day,
                        mealType = new MealTypeDTO
                        {
                            id = bmd.Meal.mealType.id,
                            type = bmd.Meal.mealType.type
                        },
                        Menus = bmd.Meal.Menus.Select(menu => new MenuDTO
                        {
                            id = menu.id,
                            name = menu.name
                        }).ToList()
                    }
                }).ToList()
            }).ToList();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getAllBookMealRecordByEmpId([FromRoute] Guid id)
        {
            var bookedMeals = await bookingMealRepo.getBookMyMealByEmpId(id);

            if (!bookedMeals.Any())
            {
                return NotFound("No booking records found for the specified employee ID.");
            }

            var response = bookedMeals.Select(bookmeal => new BookMealDTO
            {
                id = bookmeal.id,
                bookingDate = bookmeal.bookingDate,
                Note = bookmeal.Note,
                payment = bookmeal.payment,
                Status = bookmeal.Status,
                employee = new EmployeeDTO
                {
                    Id = bookmeal.employee.Id,
                    FirstName = bookmeal.employee.FirstName,
                    LastName = bookmeal.employee.LastName,
                    Phone = bookmeal.employee.Phone,
                    Email = bookmeal.employee.Email,
                    Department = new DepartmentDTO
                    {
                        Id = bookmeal.employee.Department.Id,
                        DeptName = bookmeal.employee.Department.DeptName
                    }
                },
                BookedMealDetails = bookmeal.BookedMealDetails.Select(bmd => new BookedMealDetailsDTO
                {
                    Id = bmd.Id,
                    Date = bmd.Date,
                    NumberOfMeal = bmd.NumberOfMeal,
                    Meal = new MealDTO
                    {
                        Id = bmd.Meal.Id,
                        name = bmd.Meal.name,
                        day = bmd.Meal.day,
                        description = bmd.Meal.description,
                        price = bmd.Meal.price,
                        mealType = new MealTypeDTO
                        {
                            id = bmd.Meal.mealType.id,
                            type = bmd.Meal.mealType.type
                        },
                        Menus = bmd.Meal.Menus.Select(menu => new MenuDTO
                        {
                            id = menu.id,
                            name = menu.name
                        }).ToList()
                    }
                }).ToList()
            }).ToList();

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}/cancel")]
        public async Task<IActionResult> CancelBookingByBookingId([FromRoute] Guid id)
        {
            // Attempt to cancel the booking
            var bookmeal = await bookingMealRepo.cancelBooking(id);

            // Check if the booking exists
            if (bookmeal == null)
            {
                return NotFound(new { Message = "Booking not found." });
            }
            var response = new BookMealDTO()
            {
                id = bookmeal.id,
                bookingDate = bookmeal.bookingDate,
                Note = bookmeal.Note,
                payment = bookmeal.payment,
                Status = bookmeal.Status,
                employee = new EmployeeDTO
                {
                    Id = bookmeal.employee.Id,
                    FirstName = bookmeal.employee.FirstName,
                    LastName = bookmeal.employee.LastName,
                    Phone = bookmeal.employee.Phone,
                    Email = bookmeal.employee.Email,
                    Department = new DepartmentDTO
                    {
                        Id = bookmeal.employee.Department.Id,
                        DeptName = bookmeal.employee.Department.DeptName
                    }
                },
                BookedMealDetails = bookmeal.BookedMealDetails.Select(bmd => new BookedMealDetailsDTO
                {
                    Id = bmd.Id,
                    Date = bmd.Date,
                    NumberOfMeal = bmd.NumberOfMeal,
                    Meal = new MealDTO
                    {
                        Id = bmd.Meal.Id,
                        name = bmd.Meal.name,
                        day = bmd.Meal.day,
                        description = bmd.Meal.description,
                        price = bmd.Meal.price,
                        mealType = new MealTypeDTO
                        {
                            id = bmd.Meal.mealType.id,
                            type = bmd.Meal.mealType.type
                        },
                        Menus = bmd.Meal.Menus.Select(menu => new MenuDTO
                        {
                            id = menu.id,
                            name = menu.name
                        }).ToList()
                    }
                }).ToList()
            };

            return Ok(response);
        }

    }
}
