using BookMyMeal.Data;
using BookMyMeal.Models.Domain;
using BookMyMeal.Respositaries.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookMyMeal.Respositaries.Impemention
{
    public class EmployeeRepo:IEmployeeRepo
    {
        private readonly BookMyMealDbContext _context;

        public EmployeeRepo(BookMyMealDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Employee> createEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> empLogin(string userName, string password)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Email==userName && x.Password == password);
        }
    }
}
