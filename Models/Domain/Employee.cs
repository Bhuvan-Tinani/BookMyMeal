namespace BookMyMeal.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<BookMeal> BookMeals { get; set; }

    }
}
