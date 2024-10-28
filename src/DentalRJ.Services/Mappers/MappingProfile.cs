using AutoMapper;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Model;
using TransferoHR.Services.Model.Generic;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CompanyCreateModel, Company>();
        CreateMap<CompanyUpdateModel, Company>();
        CreateMap<Company, CompanyGetModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<JobLevelCreateModel, JobLevel>();
        CreateMap<JobLevelUpdateModel, JobLevel>();
        CreateMap<JobLevel, JobLevelGetModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<JobTitleCreateModel, JobTitle>();
        CreateMap<JobTitleUpdateModel, JobTitle>();
        CreateMap<JobTitle, JobTitleGetModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}
