using System.ComponentModel.DataAnnotations;
using DentalRJ.Domain.Exceptions;

namespace DentalRJ.Domain.Entities.Base;

public class NamedBaseEntity : BaseEntity
{
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public override void Validate()
    {
        base.Validate();
        DomainException.When(String.IsNullOrWhiteSpace(Name), "Name cannot be empty!");
    }
}