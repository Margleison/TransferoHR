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

        CreateMap<ClinicCreateModel, Clinic>();
        CreateMap<ClinicUpdateModel, Clinic>();
        CreateMap<Clinic, ClinicGetModel>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<DentalInsuranceCreateModel, DentalInsurance>();
        CreateMap<DentalInsuranceUpdateModel, DentalInsurance>();
        CreateMap<DentalInsurance, DentalInsuranceGetModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<DentistCreateModel, Dentist>();
        CreateMap<DentistUpdateModel, Dentist>();
        CreateMap<Dentist, DentistGetModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<NamedCreateModel, Dentistry>();
        CreateMap<NamedUpdateModel, Dentistry>();
        CreateMap<Dentistry, NamedGetModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<PatientCreateModel, Patient>();
        CreateMap<PatientUpdateModel, Patient>();
        CreateMap<Patient, PatientGetModel>()
                .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}
