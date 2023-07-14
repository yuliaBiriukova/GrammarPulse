using GrammarPulse.BLL.Entities;

namespace GrammarPulse.BLL.Repositories;

public interface ILevelRepository
{
    Task<IEnumerable<Level>> GetAllAsync();

    Task<int> AddAsync(Level level);

    Task UpdateAsync(Level level);

    Task DeleteAsync(int id);
}