using BookMyMeal.Models.Domain;
using BookMyMeal.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealMenuController : ControllerBase
    {
        [HttpPost]
        [Route("Menu")]
        public async Task<IActionResult> createMenu(MenuRequestDTO request)
        {
            var listMenus = new List<Menu>();
            foreach(var menu in request.Menus)
            {
                var MENU=new Menu();
                MENU.name = menu;
                listMenus.Add(MENU);
            }
        }
    }
}
