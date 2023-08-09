using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace GrammarPulse.Infrasructure.Mapping;

public class TopicProfile : Profile
{
    public TopicProfile()
    {
        CreateMap<TopicDto, Topic>();

        CreateMap<Topic, TopicDto>()
            .ForMember(dest => dest.Version, opt => opt.MapFrom(
                src => src.Versions.IsNullOrEmpty() ? 0 : src.Versions.Last().Version));

        CreateMap<TopicDto, TopicViewModel>().ReverseMap();

        CreateMap<TopicAddViewModel, TopicDto>();
    }
}