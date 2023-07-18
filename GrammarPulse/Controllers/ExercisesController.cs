using AutoMapper;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Services;
using GrammarPulse.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GrammarPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IMapper mapper, IExerciseService exerciseService)
        {
            _mapper = mapper;
            _exerciseService = exerciseService;
        }

        [HttpGet("{topicId}")]
        public async Task<IEnumerable<ExerciseViewModel>> GetByTopicId(int topicId)
        {
            var exercises = await _exerciseService.GetByTopicIdAsync(topicId);
            return _mapper.Map<IEnumerable<ExerciseViewModel>>(exercises);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add(ExerciseAddViewModel model)
        {
            var id = await _exerciseService.AddAsync(_mapper.Map<ExerciseDto>(model));
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ExerciseViewModel model)
        {
            await _exerciseService.UpdateAsync(_mapper.Map<ExerciseDto>(model));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _exerciseService.DeleteAsync(id);
            return Ok();
        }
    }
}