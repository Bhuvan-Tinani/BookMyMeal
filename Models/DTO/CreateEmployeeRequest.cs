using BookMyMeal.Models.Domain;

namespace BookMyMeal.Models.DTO
{
    public class CreateEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid deptId { get; set; }
    }
}
