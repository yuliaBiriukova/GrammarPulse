using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.ViewModels;

namespace GrammarPulse.Infrasructure;

public class TopicProfile : Profile
{
    public TopicProfile() 
    {
        CreateMap<TopicDto, Topic>().ReverseMap();
        CreateMap<TopicDto, TopicViewModel>();
        CreateMap<TopicAddViewModel, TopicDto>();
    }
}