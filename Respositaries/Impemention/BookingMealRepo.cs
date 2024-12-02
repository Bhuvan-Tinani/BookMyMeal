using BookMyMeal.Data;
using BookMyMeal.Models.Domain;
using BookMyMeal.Respositaries.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookMyMeal.Respositaries.Impemention
{
    public class BookingMealRepo : IBookingMealRepo
    {
        private readonly BookMyMealDbContext _context;

        public BookingMealRepo(BookMyMealDbContext _context)
        {
            this._context = _context;
        }

        public async Task<BookMeal?> cancelBooking(Guid bookId)
        {
            var booking = await _context.BookMeals
            .Include(bm => bm.employee)
                    .ThenInclude(bm => bm.Department)
                .Include(bm => bm.BookedMealDetails)
                            .ThenInclude(bmd => bmd.Meal)
                                .ThenInclude(meal => meal.mealType)
                .Include(bm => bm.BookedMealDetails)
                            .ThenInclude(bmd => bmd.Meal)
                            .ThenInclude(meal => meal.Menus)
            .FirstOrDefaultAsync(b => b.id == bookId);

            if (booking == null)
            {
                return null;
            }
            booking.Status = "canceled";
            await _context.SaveChangesAsync();

            // Return the updated booking
            return booking;
        }

        public async Task<BookMeal> createBookMealAsync(BookMeal bookMeal)
        {
            await _context.BookMeals.AddAsync(bookMeal);
            await _context.SaveChangesAsync();
            return await _context.BookMeals
            .Include(bm => bm.BookedMealDetails)
            .ThenInclude(bmd => bmd.Meal) 
            .FirstOrDefaultAsync(bm => bm.id == bookMeal.id);
        }

        public async Task<IEnumerable<BookMeal>> getBookMyMeal()
        {
            /*return await _context.BookMeals
                        .Include(bm => bm.employee)
                        .Include(bm => bm.BookedMealDetails)
                            .ThenInclude(bmd => bmd.Meal)
                                .ThenInclude(meal => meal.mealType)
                        .Include(bm => bm.BookedMealDetails)
                            .ThenInclude(bmd => bmd.Meal)
                            .ThenInclude(meal => meal.Menus)
                        .ToListAsync();*/
            return await _context.BookMeals
                .Include(bm => bm.employee)
                    .ThenInclude(bm=> bm.Department)
                .Include(bm => bm.BookedMealDetails)
                            .ThenInclude(bmd => bmd.Meal)
                                .ThenInclude(meal => meal.mealType)
                .Include(bm => bm.BookedMealDetails)
                            .ThenInclude(bmd => bmd.Meal)
                            .ThenInclude(meal => meal.Menus)
                .ToListAsync();

        }

        public async Task<IEnumerable<BookMeal>> getBookMyMealByEmpId(Guid empId)
        {
            return await _context.BookMeals
                 .Include(bm => bm.employee)
                            .ThenInclude(bm => bm.Department)
                .Include(bm => bm.BookedMealDetails)
                            .ThenInclude(bmd => bmd.Meal)
                                .ThenInclude(meal => meal.mealType)
                .Include(bm => bm.BookedMealDetails)
                            .ThenInclude(bmd => bmd.Meal)
                            .ThenInclude(meal => meal.Menus)
                .Where(bm => bm.employee.Id == empId)
                .ToListAsync();
        }

    }
}
