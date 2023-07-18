using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Repositories;
using GrammarPulse.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace GrammarPulse.DAL.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly GrammarPulseDbContext _dbContext;

    public ExerciseRepository(GrammarPulseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Exercise>> GetByTopicIdAsync(int topicId)
    {
        return await _dbContext.Exercises.Where(e => e.TopicId == topicId).ToListAsync(); ;
    }

    public async Task<int> AddAsync(Exercise exercise)
    {
        _dbContext.Add(exercise);
        await _dbContext.SaveChangesAsync();
        return exercise.Id;
    }

    public async Task UpdateAsync(Exercise exercise)
    {
        _dbContext.Update(exercise);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        _dbContext.Remove(new Exercise { Id = id });
        await _dbContext.SaveChangesAsync();
    } 
}