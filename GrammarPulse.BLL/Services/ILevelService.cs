using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;

namespace GrammarPulse.BLL.Services;

public interface ILevelService
{
    Task<IEnumerable<LevelDto>> GetAllAsync();

    Task<int> AddAsync(LevelDto level);

    Task UpdateAsync(LevelDto level);

    Task DeleteAsync(int id);
}