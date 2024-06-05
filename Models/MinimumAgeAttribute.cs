using System;
using System.ComponentModel.DataAnnotations;
using SalesWebMvc.Services;

namespace SalesWebMvc.Models;

public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
        ErrorMessage = "The minimum age is {0} years.";
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        try
        {
            if (value is DateTime birthDate)
            {
                if (!ValidationService.ValidateAge(birthDate, _minimumAge))
                {
                    return new ValidationResult(FormatErrorMessage(_minimumAge.ToString()));
                }
            }
            else
            {
                return new ValidationResult("Data inválida");
            }

            return ValidationResult.Success!;
        }
        catch (Exception ex)
        {
            // Log the exception, if you have a logging framework
            return new ValidationResult($"An error occurred while validating the input: {ex.Message}");
        }
    }
}
