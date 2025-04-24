using AutoMapper;
using LivroDeReceitas.Communication.Requests;
using LivroDeReceitas.Domain.Entities;

namespace LivroDeReceitas.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
    }

    public void RequestToDomain()
    {
        CreateMap<UserRegisterDTO, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
    }

    private void DomainToRequest()
    {
    }
}