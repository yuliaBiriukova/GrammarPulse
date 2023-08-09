using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.ViewModels;

namespace GrammarPulse.Infrasructure.Mapping;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<Exercise, ExerciseDto>().ReverseMap();
        CreateMap<ExerciseAddViewModel, ExerciseDto>();
        CreateMap<ExerciseDto, ExerciseViewModel>().ReverseMap();
    }
}