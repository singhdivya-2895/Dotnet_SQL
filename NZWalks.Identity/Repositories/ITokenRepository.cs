using Microsoft.AspNetCore.Identity;

namespace NZWalks.Identity.Repositories
{
    public interface ITokenRepository
    { 
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
