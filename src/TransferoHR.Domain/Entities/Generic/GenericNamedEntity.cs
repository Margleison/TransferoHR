using System.ComponentModel.DataAnnotations;
using TransferoHR.Domain.Exceptions;
using TransferoHR.Domain.Utils;

namespace TransferoHR.Domain.Entities.Generic;

public class GenericNamedEntity : GenericEntity
{
    [MaxLength(100)]
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;

    protected void ValidateName() 
    {
        ValidateStringEmptyAndLenght("Name");
        DomainException.When(Name.Length > 100, "Name cannot exceed 100 characters");
    }


    public override void Validate()
    {
        base.Validate();
        ValidateName();


    }
}