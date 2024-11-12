using Microsoft.AspNetCore.Identity;

namespace BookMyMeal.Respositaries.Interface
{
    public interface ITokenRepo
    {
        string createJwtToken(IdentityUser user, List<string> roles);
    }
}
