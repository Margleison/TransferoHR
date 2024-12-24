using AutoMapper;
using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Entities.Generic;
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
        
        
        CreateMap<DepartmentCreateModel, Department>();
        CreateMap<DepartmentUpdateModel, Department>();
        CreateMap<Department, DepartmentGetModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<CollaboratorCreateModel, Collaborator>();
        CreateMap<CollaboratorUpdateModel, Collaborator>();
        CreateMap<Collaborator, CollaboratorGetModel>();

        CreateMap<WorkExperienceCreateModel, WorkExperience>();
        CreateMap<WorkExperienceUpdateModel, WorkExperience>();
        CreateMap<WorkExperience, WorkExperienceGetModel>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<NamedCreateModel, GenericNamedEntity>();
        CreateMap<NamedUpdateModel, GenericNamedEntity>();
        CreateMap<GenericNamedEntity, NamedGetModel>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

    }
}
