using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;

namespace GrammarPulse.BLL.Services;

public interface IUserService
{
    Task<int> AddUserAsync(UserDto user);

    Task<UserDto?> GetUserByEmailAsync(string email);
}