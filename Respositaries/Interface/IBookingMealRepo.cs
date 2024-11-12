using BookMyMeal.Models.Domain;

namespace BookMyMeal.Respositaries.Interface
{
    public interface IBookingMealRepo
    {
        Task<BookMeal> createBookMealAsync(BookMeal bookMeal);
        Task<IEnumerable<BookMeal>> getBookMyMeal();
        Task<IEnumerable<BookMeal>> getBookMyMealByEmpId(Guid id);
    }
}
