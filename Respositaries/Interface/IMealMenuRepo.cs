using BookMyMeal.Models.Domain;

namespace BookMyMeal.Respositaries.Interface
{
    public interface IMealMenuRepo
    {
        Task<List<Menu>> createAsyncMenus(List<Menu> listMenu);
        Task<MealType> GetMealType(int id);
        Task<Menu> getMenu(int id);
        Task<Meal> createMealAsync(Meal meal);
        Task<IEnumerable<Menu>> getAllMenuAsync();
        Task<IEnumerable<Meal>> getAllMealAsync();
        Task<Meal?> getMealById(int id);
        Task<IEnumerable<string>> getDayByMealWhichNotUsed();
        Task<Meal?> updateMeal(Meal meal);
        Task<Meal?> getMealByDay(string day);
    }
}
