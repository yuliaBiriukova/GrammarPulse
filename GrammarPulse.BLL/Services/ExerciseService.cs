using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Repositories;

namespace GrammarPulse.BLL.Services;

public class ExerciseService : IExerciseService
{
    private readonly IMapper _mapper;
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IMapper mapper, IExerciseRepository exerciseRepository)
    {
        _mapper = mapper;
        _exerciseRepository = exerciseRepository;
    }

    public async Task<IEnumerable<ExerciseDto>> GetByTopicIdAsync(int topicId)
    {
        var exercises = await _exerciseRepository.GetByTopicIdAsync(topicId);
        return _mapper.Map<IEnumerable<ExerciseDto>>(exercises);
    }

    public async Task<int> AddAsync(ExerciseDto exercise)
    {
        var newExercise = _mapper.Map<Exercise>(exercise);
        return await _exerciseRepository.AddAsync(newExercise);
    }

    public async Task UpdateAsync(ExerciseDto exercise)
    {
        var updatedExercise = _mapper.Map<Exercise>(exercise);
        await _exerciseRepository.UpdateAsync(updatedExercise);
    }

    public async Task DeleteAsync(int id)
    {
        await _exerciseRepository.DeleteAsync(id);
    }
}