using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Exceptions;
using TransferoHR.Domain.Validators;

namespace TransferoHR.Domain.Entities
{
    public class WorkExperience : GenericEntity 
    {
        public required Guid CollaboratorId { get; set; }
        public required DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public required Guid CompanyId {  get; set; } 
        public required Guid JobTitleId { get; set; }
        public required Guid JobLevelId { get; set; }
        public required Guid LeaderId { get; set; }

        public Company Company { get; set; }
        public JobTitle JobTitle {  get; set; }
        public  JobLevel JobLevel { get; set; }
        public Collaborator Collaborator { get; set; }
        public Collaborator Leader { get; set; }
        
        private void ValidateRequired()
        {
            if (CompanyId == Guid.Empty)
            {
                throw new DomainException("Company ID cannot be empty.");
            }

            if (JobTitleId == Guid.Empty)
            {
                throw new DomainException("Job Title ID cannot be empty.");
            }

            if (JobLevelId == Guid.Empty)
            {
                throw new DomainException("Job Level ID cannot be empty.");
            }

            if (LeaderId == Guid.Empty)
            {
                throw new DomainException("Leader ID cannot be empty.");
            }

            if (CollaboratorId == Guid.Empty)
            {
                throw new DomainException("Leader ID cannot be empty.");
            }
        }
        public void Activate()
        {
            throw new InvalidOperationException("WorkExperience cannot be activated.");
        }

        public void Deactivate()
        {
            throw new InvalidOperationException("WorkExperience cannot be deactivated.");
        }
        private void ValidateDate()
        {
            // Verifica se a data de início é igual à data de fim
            if (StartDate == EndDate)
            {
                throw new DomainException("Start Date and End Date cannot be the same.");
            }

            // Verifica se a data de fim é anterior à data de início
            if (EndDate < StartDate)
            {
                throw new DomainException("End Date cannot be earlier than Start Date.");
            }
        }

        public override void Validate()
        {
            ValidateDate();
            ValidateRequired();
            Activate();
            Deactivate();
        }


    }
}
                                                                                                        