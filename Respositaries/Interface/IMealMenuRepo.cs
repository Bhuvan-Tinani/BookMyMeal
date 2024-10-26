using BookMyMeal.Models.Domain;

namespace BookMyMeal.Respositaries.Interface
{
    public interface IMealMenuRepo
    {
        List<Menu> createAsyncMenus(List<Menu> listMenu); 
    }
}
