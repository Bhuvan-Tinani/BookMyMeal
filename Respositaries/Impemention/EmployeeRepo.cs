using BookMyMeal.Data;

namespace BookMyMeal.Respositaries.Impemention
{
    public class EmployeeRepo
    {
        private readonly BookMyMealDbContext _context;

        public EmployeeRepo(BookMyMealDbContext _context)
        {
            this._context = _context;
        }
    }
}
