using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Services;

public class ValidationService
{
    public static bool ValidateAge(DateTime birthDate, int minimumAge)
    {
        if (DateTime.Now < birthDate || (DateTime.Now.Year - birthDate.Year) < minimumAge)
        {
            return false; // Not valid
        }
        return true; // Valid
    }
}

