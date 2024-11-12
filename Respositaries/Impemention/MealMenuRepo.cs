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

        public async Task<IEnumerable<string>> getDayByMealWhichNotUsed()
        {
            // List of all days of the week
            var allDays = new List<string> { "sunday", "monday", "tuesday", "wednesday", "thursday", "friday", "saturday" };

            var usedDays = await _context.Meals
                                        .Select(m => m.day)
                                        .Distinct()  
                                        .ToListAsync();

            var unusedDays = allDays.Except(usedDays).ToList();

            return unusedDays;
        }

        public async Task<Meal?> getMealByDay(string day)
        {
            return await _context.Meals.Include(x => x.mealType)
                .Include(x => x.Menus).FirstOrDefaultAsync(x => x.day.Equals(day));
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

        public async Task<Meal?> updateMeal(Meal meal)
        {
            var existingMeal = await _context.Meals.FirstOrDefaultAsync(x=>x.Id==meal.Id);
            if(existingMeal is null)
            {
                return null;
            }
            _context.Entry(existingMeal).CurrentValues.SetValues(meal);
            await _context.SaveChangesAsync();
            return meal;
        }
    }
}
