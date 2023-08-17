using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;

namespace GrammarPulse.BLL.Services;

public interface ICompletedTopicService
{
    Task<int> AddAsync(CompletedTopicDto completedTopic);

    Task<CompletedTopicDto?> GetAsync(int topicId, int userId);

    Task<IEnumerable<CompletedTopicDto>> GetByLevelAsync(int levelId, int userId);

    Task UpdateAsync(CompletedTopicDto completedTopic);
}