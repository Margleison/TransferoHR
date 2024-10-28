using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Validators;
using TransferoHR.Domain.Exceptions;

namespace TransferoHR.Domain.Entities;


public class Company : GenericNamedEntity
{ 
    public required string CNPJ { get; init; }

    public override void Validate()
    {
        base.Validate();
        DomainException.When(string.IsNullOrWhiteSpace(CNPJ), "CNPJ cannot be empty!");
        DomainException.When(CNPJValidator.Validate(CNPJ) == false, "Invalid CNPJ!");
    }

}

