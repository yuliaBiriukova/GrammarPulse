using GrammarPulse.BLL.Entities;

namespace GrammarPulse.BLL.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);

    Task<int> AddUserAsync(User user);
}