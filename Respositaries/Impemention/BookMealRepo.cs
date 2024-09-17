using BookMyMeal.Data;
using BookMyMeal.Respositaries.Interface;

namespace BookMyMeal.Respositaries.Impemention
{
    public class BookMealRepo: IBookMealRepo
    {
        private readonly BookMyMealDbContext _context;

        public BookMealRepo(BookMyMealDbContext _context)
        {
            this._context = _context;
        }
    }
}
