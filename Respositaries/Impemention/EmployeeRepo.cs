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

        public async Task<IEnumerable<Employee>> getAllEmployees()
        {
            return await _context.Employees.Include(x=>x.Department).ToListAsync();
        }

        public async Task<Employee?> getEmpByIdAsync(Guid id)
        {
            var emp = await _context.Employees.Include(x=>x.Department).FirstOrDefaultAsync(x => x.Id == id);
            if(emp is null)
            {
                return null;
            }
            return emp;
        }

        public async Task<Guid?> getEmpId(string userName)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(x => x.Email == userName);
            return emp.Id;
        }
    }
}
