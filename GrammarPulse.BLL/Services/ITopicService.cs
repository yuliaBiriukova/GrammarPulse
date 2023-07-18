using GrammarPulse.BLL.Models;

namespace GrammarPulse.BLL.Services;

public interface ITopicService
{
    Task<IEnumerable<TopicDto>> GetByLevelIdAsync(int levelId);

    Task<TopicDto> GetByIdAsync(int id);

    Task<int> AddAsync(TopicDto topic);

    Task UpdateAsync(TopicDto topic);

    Task DeleteAsync(int id);
}