using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.ViewModels;

namespace GrammarPulse.Infrasructure.Mapping;

public class CompletedTopicProfile : Profile
{
    public CompletedTopicProfile()
    {
        CreateMap<CompletedTopic, CompletedTopicDto>().ReverseMap();
        CreateMap<CompletedTopicViewModel, CompletedTopicDto>().ReverseMap();
        CreateMap<AddCompletedTopicViewModel, CompletedTopicDto>();
    }
}