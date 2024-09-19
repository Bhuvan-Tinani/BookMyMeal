using BookMyMeal.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookMyMeal.Data
{
    public class BookMyMealDbContext : DbContext
    {
        public BookMyMealDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
    }
}
