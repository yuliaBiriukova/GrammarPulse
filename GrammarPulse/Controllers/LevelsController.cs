using AutoMapper;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Services;
using GrammarPulse.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrammarPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILevelService _levelService;

        public LevelsController(IMapper mapper, ILevelService levelService)
        {
            _mapper = mapper;
            _levelService = levelService;
        }

        [HttpGet]
        public async Task<IEnumerable<LevelViewModel>> GetAll()
        {
            var levels = await _levelService.GetAllAsync();
            return _mapper.Map<IEnumerable<LevelViewModel>>(levels);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<LevelAddViewModel>> Add(LevelAddViewModel model)
        {
            var id  = await _levelService.AddAsync(_mapper.Map<LevelDto>(model));
            return Ok(id);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<LevelViewModel>> Update(int id, [FromBody]LevelViewModel model)
        {
            await _levelService.UpdateAsync(_mapper.Map<LevelDto>(model));
            return Ok(model);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _levelService.DeleteAsync(id);
            return Ok();
        }
    }
}