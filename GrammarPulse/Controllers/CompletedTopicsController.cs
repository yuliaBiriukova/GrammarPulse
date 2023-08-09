using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Services;
using GrammarPulse.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrammarPulse.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompletedTopicsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICompletedTopicService _completedTopicService;

    public CompletedTopicsController(IMapper mapper, ICompletedTopicService completedTopicService)
    {
        _mapper = mapper;
        _completedTopicService = completedTopicService;
    }

    [HttpGet]
    public async Task<CompletedTopicViewModel> Get(int topicId, int userId)
    {
        var completedTopic = await _completedTopicService.GetAsync(topicId, userId);
        return _mapper.Map<CompletedTopicViewModel>(completedTopic);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<int>> Add(AddCompletedTopicViewModel model)
    {
        var id = await _completedTopicService.AddAsync(_mapper.Map<CompletedTopicDto>(model));
        return Ok(id);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Update(int id, CompletedTopicViewModel model)
    {
        await _completedTopicService.UpdateAsync(_mapper.Map<CompletedTopicDto>(model));
        return Ok();
    }
}