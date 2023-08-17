using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;

namespace GrammarPulse.BLL.Repositories;

public interface IUserRepository
{
    Task<int> AddUserAsync(User user);

    Task<User?> GetUserByEmailAsync(string email);

    Task<User> GetUserByIdAsync(int id);

}