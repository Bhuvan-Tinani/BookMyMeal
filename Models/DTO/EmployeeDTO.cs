using BookMyMeal.Models.Domain;

namespace BookMyMeal.Models.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
