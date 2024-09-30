using BookMyMeal.Data;
using BookMyMeal.Models.Domain;
using BookMyMeal.Respositaries.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookMyMeal.Respositaries.Impemention
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly BookMyMealDbContext _context;

        public DepartmentRepo(BookMyMealDbContext context)
        {
            _context = context;
        }

        public async Task<Department> createNewDepartment(Department department)
        {
            await _context.Department.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department?> deleteDepartmentById(Guid id)
        {
            var department= await _context.Department.FirstOrDefaultAsync(x=> x.Id==id);
            if(department is null)
            {
                return null;
            }
            _context.Department.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<IEnumerable<Department>> getAllDepartments()
        {
            return await _context.Department.ToListAsync();
        }

        public async Task<Department?> getDepartmentById(Guid id)
        {
            return await _context.Department.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
