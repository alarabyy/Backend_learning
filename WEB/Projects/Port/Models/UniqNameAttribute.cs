using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Port.Models
{
    public class UniqNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            string newName = value.ToString();

            // Get ApplicationDbContext from DI
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            if (context == null)
            {
                throw new InvalidOperationException("ApplicationDbContext is not available.");
            }

            bool nameExists = context.Orders.Any(s => s.OrderName == newName);
            if (nameExists)
            {
                return new ValidationResult("Name must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
