
using DentalRJ.Domain.Enums;
using DentalRJ.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace DentalRJ.Domain.Entities.Base;

public class BaseEntity
{
    public Guid Id { get; set; }
    public EntityStatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }
    [MaxLength(100)]
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? UpdatedAt { get; set; }
    [MaxLength(100)]
    public string? UpdatedBy { get; set; }

    public virtual void Validate()
    {
        DomainException.When(string.IsNullOrWhiteSpace(CreatedBy), "Created By cannot be empty");
        if (UpdatedAt != null) DomainException.When(string.IsNullOrWhiteSpace(UpdatedBy), "Updated By cannot be empty");
        if (UpdatedBy != null) DomainException.When(UpdatedAt == null, "Updated At cannot be empty");
    }
}