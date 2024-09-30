using BookMyMeal.Models.Domain;

namespace BookMyMeal.Respositaries.Interface
{
    public interface IDepartmentRepo
    {
        Task<Department> createNewDepartment(Department department);
        Task<IEnumerable<Department>> getAllDepartments();
        Task<Department?> getDepartmentById(Guid id);
        Task<Department?> deleteDepartmentById(Guid id);
    }
}
