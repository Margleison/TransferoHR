using System.ComponentModel.DataAnnotations;
using TransferoHR.Domain.Exceptions;

namespace TransferoHR.Domain.Entities.Generic;

public class GenericNamedEntity : GenericEntity
{
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public override void Validate()
    {
        base.Validate();
        DomainException.When(String.IsNullOrWhiteSpace(Name), "Name cannot be empty!");
        DomainException.When(Name.Length > 100, "Name cannot exceed 100 characters");
    }
}