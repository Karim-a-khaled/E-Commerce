using PartTwo.Entities.Entities.Identity;

namespace PartTwo.Services.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}
