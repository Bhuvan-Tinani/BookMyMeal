using BookMyMeal.Models.Domain;

namespace BookMyMeal.Respositaries.Interface
{
    public interface IEmployeeRepo
    {
        Task<Employee> createEmployee(Employee employee);
        Task<Employee?> empLogin(string userName,string password);
        Task<Employee?> getEmpByIdAsync(Guid id);

        Task<Guid?> getEmpId(string userName); 
        Task<IEnumerable<Employee>> getAllEmployees();
    }
}
