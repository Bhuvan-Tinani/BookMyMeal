using BookMyMeal.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookMyMeal.Data
{
    public class BookMyMealDbContext : DbContext
    {
        public BookMyMealDbContext(DbContextOptions<BookMyMealDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<BookMeal> BookMeals { get; set; }
        public DbSet<BookedMealDetails> BookedMealsDetails { get; set; }
    }
}
