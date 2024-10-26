using BookMyMeal.Data;
using BookMyMeal.Models.Domain;
using BookMyMeal.Respositaries.Interface;

namespace BookMyMeal.Respositaries.Impemention
{
    public class MealMenuRepo : IMealMenuRepo
    {
        private readonly BookMyMealDbContext _context;

        public MealMenuRepo(BookMyMealDbContext _context)
        {
            _context = _context;
        }

        public async List<Menu> createAsyncMenus(List<Menu> listMenu)
        {
            foreach (var menu in listMenu)
            {
                await _context.M
            }
        }
    }
}
