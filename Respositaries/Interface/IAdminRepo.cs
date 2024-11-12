using BookMyMeal.Models.Domain;

namespace BookMyMeal.Respositaries.Interface
{
    public interface IAdminRepo
    {
        Task<Admin> createAdmin(Admin admin);
        Task<Guid?> getAdminId(string username);
    }
}
