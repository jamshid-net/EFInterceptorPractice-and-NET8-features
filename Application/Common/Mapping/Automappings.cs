using Application.UseCases.UserContentService.Commands;
using AutoMapper;
using Domain.Models;

namespace Application.Common.Mapping;
public class Automappings : Profile
{
    public Automappings()
    {
        CreateMap<CreateUserContentCommand, UserContent>().ReverseMap();
    }
}
