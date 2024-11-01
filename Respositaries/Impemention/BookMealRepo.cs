using BookMyMeal.Data;
using BookMyMeal.Respositaries.Interface;

namespace BookMyMeal.Respositaries.Impemention
{
    public class BookMealRepo: IBookMealRepo
    {
        private readonly BookMyMealDbContext _context;

        public BookMealRepo(BookMyMealDbContext context)
        {
            this._context = context;
        }

        public void hello(int id)
        {
            throw new NotImplementedException();
        }
    }
}
