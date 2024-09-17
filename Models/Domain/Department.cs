namespace BookMyMeal.Models.Domain
{
    public class Department
    {
        public Guid Id { get; set; }
        public string DeptName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
