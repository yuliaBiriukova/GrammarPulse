using GrammarPulse.BLL.Models;

namespace GrammarPulse.BLL.Services;

public interface ICompletedTopicService
{
    Task<int> AddAsync(CompletedTopicDto completedTopic);

    Task<CompletedTopicDto?> GetAsync(int topicId, int userId);

    Task UpdateAsync(CompletedTopicDto completedTopic);
}