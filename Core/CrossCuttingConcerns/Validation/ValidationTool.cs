using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns.Validation;

public static class ValidationTool
{
    public static void Validate(IValidator validator,object entity)
    {
        var contex = new ValidationContext<object>(entity);
        var result = validator.Validate(contex);
        if (result != null)
        {
            throw new ValidationException(result.Errors);
        }
    }
}