using AutoMapper;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Services;
using GrammarPulse.ViewModels;
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

    [HttpPost]
    public async Task<ActionResult<TopicAddViewModel>> Add(TopicAddViewModel model)
    {
        var id = await _topicService.AddAsync(_mapper.Map<TopicDto>(model));
        return Ok(model);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TopicViewModel>> Update(int id, [FromBody]TopicViewModel model)
    {
        await _topicService.UpdateAsync(_mapper.Map<TopicDto>(model));
        return Ok(model);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _topicService.DeleteAsync(id);
        return Ok();
    }
}