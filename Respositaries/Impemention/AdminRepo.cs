using BookMyMeal.Data;
using BookMyMeal.Models.Domain;
using BookMyMeal.Respositaries.Interface;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Guid?> getAdminId(string username)
        {
            var admin= await _context.Admin.FirstOrDefaultAsync(x=> x.Username == username);
            return admin?.Id;
        }
    }
}
