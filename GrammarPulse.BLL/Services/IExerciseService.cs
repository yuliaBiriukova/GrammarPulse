using GrammarPulse.BLL.Models;

namespace GrammarPulse.BLL.Services;

public interface IExerciseService
{
    Task<IEnumerable<ExerciseDto>> GetByTopicIdAsync(int topicId);

    Task<int> AddAsync(ExerciseDto exercise);

    Task UpdateAsync(ExerciseDto exercise);

    Task DeleteAsync(int id);
}