using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.ViewModels;

namespace GrammarPulse.Infrasructure.Mapping;

public class LevelProfile : Profile
{
    public LevelProfile()
    {
        CreateMap<Level, LevelDto>().ReverseMap();
        CreateMap<LevelAddViewModel, LevelDto>();
        CreateMap<LevelDto, LevelViewModel>().ReverseMap();
    }
}