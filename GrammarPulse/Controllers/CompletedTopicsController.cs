using AutoMapper;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Services;
using GrammarPulse.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GrammarPulse.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompletedTopicsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICompletedTopicService _completedTopicService;
    private readonly IUserService _userService;

    public CompletedTopicsController(IMapper mapper, ICompletedTopicService completedTopicService, IUserService userService)
    {
        _mapper = mapper;
        _completedTopicService = completedTopicService;
        _userService = userService;
    }



    [Authorize]
    [HttpGet]
    public async Task<CompletedTopicViewModel?> Get(int topicId)
    {
        var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;
        if (userEmail is not null)
        {
            var user = await _userService.GetUserByEmailAsync(userEmail);
            if (user is not null)
            {
                var completedTopic = await _completedTopicService.GetAsync(topicId, user.Id);
                return _mapper.Map<CompletedTopicViewModel>(completedTopic);
            }
        }
        return null;
    }

    [Authorize]
    [HttpGet("{levelId}")]
    public async Task<IEnumerable<CompletedTopicViewModel>> GetByLevel(int levelId)
    {
        var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;
        if (userEmail is not null)
        {
            var user = await _userService.GetUserByEmailAsync(userEmail);
            if (user is not null)
            {
                var completedTopics = await _completedTopicService.GetByLevelAsync(levelId, user.Id);
                return _mapper.Map<IEnumerable<CompletedTopicViewModel>>(completedTopics);
            }
        }
        return new List<CompletedTopicViewModel>();
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<int>> Add(AddCompletedTopicViewModel model)
    {
        var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;
        if (userEmail is not null)
        {
            var user = await _userService.GetUserByEmailAsync(userEmail);
            if (user is not null)
            {
                var completedTopicToAdd = _mapper.Map<CompletedTopicDto>(model);
                completedTopicToAdd.UserId = user.Id;
                var id = await _completedTopicService.AddAsync(completedTopicToAdd);
                return Ok(id);
            }
        }
        return Ok();
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Update(int id, CompletedTopicViewModel model)
    {
        await _completedTopicService.UpdateAsync(_mapper.Map<CompletedTopicDto>(model));
        return Ok();
    }
}