using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Repositories;

namespace GrammarPulse.BLL.Services;

public class LevelService : ILevelService
{
    private readonly IMapper _mapper;
    private readonly ILevelRepository _levelRepository;

    public LevelService(IMapper mapper, ILevelRepository levelRepository)
    {
        _mapper = mapper;
        _levelRepository = levelRepository;
    }

    public async Task<IEnumerable<LevelDto>> GetAllAsync()
    {
        var levels = await _levelRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<LevelDto>>(levels);
    }

    public async Task<int> AddAsync(LevelDto level)
    {
        var newLevel = _mapper.Map<Level>(level);
        return await _levelRepository.AddAsync(newLevel);
    }

    public async Task UpdateAsync(LevelDto level)
    {
        var updatedLevel = _mapper.Map<Level>(level);
        await _levelRepository.UpdateAsync(updatedLevel);
    }

    public async Task DeleteAsync(int id)
    {
        await _levelRepository.DeleteAsync(id);
    }
}