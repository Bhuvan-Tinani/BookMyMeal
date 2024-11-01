using BookMyMeal.Models.Domain;

namespace BookMyMeal.Respositaries.Interface
{
    public interface IBookingMealRepo
    {
        Task<BookMeal> createBookMealAsync(BookMeal bookMeal);
    }
}
