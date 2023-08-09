using AutoMapper;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Services;
using GrammarPulse.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrammarPulse.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TopicsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ITopicService _topicService;

    public TopicsController(IMapper mapper, ITopicService topicService)
    {
        _mapper = mapper;
        _topicService = topicService;
    }

    [HttpGet("{levelId}")]
    public async Task<IEnumerable<TopicViewModel>> GetByLevelId(int levelId)
    {
        var topics = await _topicService.GetByLevelIdAsync(levelId);
        return _mapper.Map<IEnumerable<TopicViewModel>>(topics);
    }

    [HttpGet("{levelId}/{id}")]
    public async Task<TopicViewModel> GetById(int levelId, int id)
    {
        var topic = await _topicService.GetByIdAsync(id);
        return _mapper.Map<TopicViewModel>(topic);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<int>> Add(TopicAddViewModel model)
    {
        var id = await _topicService.AddAsync(_mapper.Map<TopicDto>(model));
        return Ok(id);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody]TopicViewModel model)
    {
        await _topicService.UpdateAsync(_mapper.Map<TopicDto>(model));
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _topicService.DeleteAsync(id);
        return Ok();
    }
}