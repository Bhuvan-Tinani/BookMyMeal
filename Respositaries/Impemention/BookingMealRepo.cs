using BookMyMeal.Data;
using BookMyMeal.Models.Domain;
using BookMyMeal.Respositaries.Interface;

namespace BookMyMeal.Respositaries.Impemention
{
    public class BookingMealRepo : IBookingMealRepo
    {
        private readonly BookMyMealDbContext _context;

        public BookingMealRepo(BookMyMealDbContext _context)
        {
            this._context = _context;
        }

        public async Task<BookMeal> createBookMealAsync(BookMeal bookMeal)
        {
            await _context.BookMeals.AddAsync(bookMeal);
            await _context.SaveChangesAsync();
            return bookMeal;
        }
    }
}
