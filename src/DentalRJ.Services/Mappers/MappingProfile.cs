using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Model;
using DentalRJ.Services.Model.Base;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CompanyCreateModel, Company>();
        CreateMap<NamedUpdateModel, Company>();
        CreateMap<Company, NamedGetModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}
