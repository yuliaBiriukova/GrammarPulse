using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;

namespace GrammarPulse.Infrasructure.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
