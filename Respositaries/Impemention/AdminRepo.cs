using BookMyMeal.Data;
using BookMyMeal.Models.Domain;
using BookMyMeal.Respositaries.Interface;

namespace BookMyMeal.Respositaries.Impemention
{
    public class AdminRepo: IAdminRepo
    {
        private readonly BookMyMealDbContext _context;

        public AdminRepo(BookMyMealDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Admin> createAdmin(Admin admin)
        {
            await _context.Admin.AddAsync(admin);
            await _context.SaveChangesAsync();
            return admin;
        }
    }
}
