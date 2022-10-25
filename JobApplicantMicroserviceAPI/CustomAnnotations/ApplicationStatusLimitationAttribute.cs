using System.ComponentModel.DataAnnotations;

namespace JobApplicantMicroserviceAPI.CustomAnnotations
{
    public class ApplicationStatusLimitationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "Submitted" || Convert.ToString(value) == "Rejected" || Convert.ToString(value) == "Selected")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}
