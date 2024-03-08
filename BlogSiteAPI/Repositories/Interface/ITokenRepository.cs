using Microsoft.AspNetCore.Identity;

namespace BlogSite.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
