using System.ComponentModel.DataAnnotations;

namespace UserMicroserviceAPI.CustomAnnotations
{
    public class GenderValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "M" || Convert.ToString(value) == "F" || Convert.ToString(value) == "O")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);

        }
    }
}
