using GrammarPulse.BLL.Entities;

namespace GrammarPulse.BLL.Repositories;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>> GetByTopicIdAsync(int topicId);

    Task<int> AddAsync(Exercise exercise);

    Task UpdateAsync(Exercise exercise);

    Task DeleteAsync(int id);
}