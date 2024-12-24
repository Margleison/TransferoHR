using AutoMapper;
using System.ComponentModel.Design;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Exceptions;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.Services.Implementation
{
    public class WorkExperienceService : GenericService<WorkExperience, WorkExperienceParams, WorkExperienceGetModel>
    {
        private readonly IJobLevelRepository _jobLevelRepository;
        private readonly IJobTitleRepository _jobTitleRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly IWorkExperienceRepository _repo;

        public WorkExperienceService(IMapper mapper, IJobLevelRepository jobLevelRepository, IJobTitleRepository jobTitleRepository, ICompanyRepository companyRepository, ICollaboratorRepository collaboratorRepository, IWorkExperienceRepository repo) : base(mapper, repo, "Work Experience")
        {
            _jobLevelRepository = jobLevelRepository;
            _jobTitleRepository = jobTitleRepository;
            _companyRepository = companyRepository;
            _collaboratorRepository = collaboratorRepository;
            _repo = repo;
        }

        public override async Task Validate(WorkExperience entity, Guid? exId)
        {
            await base.Validate(entity, exId);
            ServiceException.When(await _collaboratorRepository.GetAsync(entity.CollaboratorId) == null, "Collaborator does not exist");
            ServiceException.When(await _companyRepository.GetAsync(entity.CompanyId) == null, "Company does not exist");
            ServiceException.When(await _jobLevelRepository.GetAsync(entity.JobLevelId) == null, "JobLevel does not exist");
            ServiceException.When(await _jobTitleRepository.GetAsync(entity.JobTitleId) == null, "JobTitle does not exist");
            // Testar ColaboratorId

            //Teste
            ServiceException.When(await _repo.Exists(entity.CompanyId, entity.CollaboratorId, entity.JobLevelId, entity.JobTitleId), $"{_entityName} Work Experience already exists. [Value={entity}]");
        }

        public override async Task Activate(Guid id, string updateBy)
        {
            throw new ServiceException("Activating a WorkExperience is not allowed.");

        }
        public override async Task Deactivate(Guid id, string updatedBy)
        {
            // Lançando uma exceção informando que não é permitido desativar uma WorkExperience
            throw new ServiceException("Deactivating a WorkExperience is not allowed.");
        }
    }
}   

