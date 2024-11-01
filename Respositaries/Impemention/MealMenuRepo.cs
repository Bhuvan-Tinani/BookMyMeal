using BookMyMeal.Data;
using BookMyMeal.Models.Domain;
using BookMyMeal.Respositaries.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookMyMeal.Respositaries.Impemention
{
    public class MealMenuRepo: IMealMenuRepo
    {
        private readonly BookMyMealDbContext _context;

        public MealMenuRepo(BookMyMealDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Menu>> createAsyncMenus(List<Menu> listMenu)
        {
            await _context.Menu.AddRangeAsync(listMenu);
            await _context.SaveChangesAsync();
            return listMenu;
        }

        public async Task<Meal> createMealAsync(Meal meal)
        {
            await _context.Meals.AddAsync(meal);
            await _context.SaveChangesAsync();
            return meal;
        }

        public async Task<IEnumerable<Meal>> getAllMealAsync()
        {
            return await _context.Meals.Include(x=>x.Menus)
                .Include(x=>x.mealType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Menu>> getAllMenuAsync()
        {
            return await _context.Menu.ToListAsync();
        }

        public async Task<Meal?> getMealById(int id)
        {
            return await _context.Meals.Include(x=>x.mealType)
                .Include(x=>x.Menus).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MealType> GetMealType(int id)
        {
            return await _context.MealTypes.FirstOrDefaultAsync(x=>x.id== id);
        }

        public async Task<Menu> getMenu(int id)
        {
            return await _context.Menu.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
