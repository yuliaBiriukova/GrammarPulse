using GrammarPulse.BLL.Entities;

namespace GrammarPulse.BLL.Repositories;

public interface ITopicRepository
{
    Task<IEnumerable<Topic>> GetByLevelIdAsync(int levelId);

    Task<Topic> GetByIdAsync(int id);

    Task<int> AddAsync(Topic topic);

    Task UpdateAsync(Topic topic);

    Task DeleteAsync(int id);
}