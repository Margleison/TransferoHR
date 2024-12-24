
using TransferoHR.Domain.Enums;
using TransferoHR.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.ComponentModel;
using System.Net;

namespace TransferoHR.Domain.Entities.Generic;

public class GenericEntity
{
    public Guid Id { get; set; }
    public EntityStatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }
    [MaxLength(100)]
    [DisplayName("Created By")]
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? UpdatedAt { get; set; }
    [MaxLength(100)]
    [DisplayName("Updated By")]
    public string? UpdatedBy { get; set; }

    protected int GetMaxLength(string propertyName)
    {
        // Usa 'GetType()' para pegar a classe atual sem necessidade de passá-la explicitamente
        var maxLengthAttribute = (MaxLengthAttribute)GetType()
            .GetProperty(propertyName)?
            .GetCustomAttribute(typeof(MaxLengthAttribute));

        return maxLengthAttribute?.Length ?? 0; // Retorna int.MaxValue se MaxLength não estiver definido
    }
    protected string GetDisplayName(string propertyName)
    {
        var displayNameAttribute = (DisplayNameAttribute)GetType()
            .GetProperty(propertyName)?
            .GetCustomAttribute(typeof(DisplayNameAttribute));

        return displayNameAttribute?.DisplayName ?? propertyName; // Retorna o nome amigável ou o nome da propriedade se não houver atributo
    }

    protected void ValidateStringEmptyAndLenght(string propertyName, Func<string, bool>? validationFunction=null)
    {
        // Usando reflection para acessar a propriedade dinamicamente
        var propertyValue = GetType().GetProperty(propertyName)?.GetValue(this) as string;

        // Verificando se a propriedade é nula ou contém espaços em branco
        if (string.IsNullOrWhiteSpace(propertyValue))
        {
            var displayName = GetDisplayName(propertyName);
            var message = $"{displayName} cannot be empty";
            throw new DomainException(message);
        }

        // Verificando o tamanho máximo da propriedade
        var maxLength = GetMaxLength(propertyName);
        if (maxLength > 0 && propertyValue.Length > maxLength)
        {
            var displayName = GetDisplayName(propertyName);
            var message = $"{displayName} cannot exceed {maxLength} characters";
            throw new DomainException(message);
        }

        // Aplicando a função de validação personalizada, se fornecida
        if (validationFunction != null && !validationFunction(propertyValue))
        {
            var displayName = GetDisplayName(propertyName);
            var message = $"Invalid {displayName}!";
            throw new DomainException(message);
        }
    }

    public virtual void Validate()
    {
        ValidateStringEmptyAndLenght("CreatedBy");

        if (UpdatedAt != null) ValidateStringEmptyAndLenght("UpdatedBy");
        if (UpdatedBy != null) DomainException.When(UpdatedAt == null, "Updated At cannot be empty");
    }
}