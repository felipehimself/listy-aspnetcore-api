using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Helpers
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class GuidValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {

                if (value is string stringValue)
                {

                    // Guid myGuid;

                    bool isValid = Guid.TryParse(stringValue, out _);

                    if (isValid) return ValidationResult.Success;


                }
            }

            return new ValidationResult(ErrorMessage ?? "The field must be a valid GUID.");
        }
    }
}