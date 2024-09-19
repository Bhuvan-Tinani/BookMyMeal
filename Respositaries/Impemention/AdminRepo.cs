using BookMyMeal.Data;
using BookMyMeal.Models.Domain;
using BookMyMeal.Respositaries.Interface;

namespace BookMyMeal.Respositaries.Impemention
{
    public class AdminRepo: IAdminRepo
    {
        private readonly BookMyMealDbContext _context;

        public AdminRepo(BookMyMealDbContext _context)
        {
            this._context = _context;
        }

    }
}
