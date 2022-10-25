using System.ComponentModel.DataAnnotations;

namespace UserMicroserviceAPI.CustomAnnotations
{
    public class RoleValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "JobSeeker" || Convert.ToString(value) == "Employer")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);

        }
    }
}
