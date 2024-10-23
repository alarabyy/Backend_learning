using System.ComponentModel.DataAnnotations;

namespace GameStore.attribute
{
    public class MaxSizeAttribute : ValidationAttribute
    {
        private readonly int _MaxFileSize;
        public MaxSizeAttribute(int MaxFileSize)
        {
            _MaxFileSize = MaxFileSize;
        }
        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file  is not null)
            {
              
                if (file.Length > _MaxFileSize)
                {
                    return new ValidationResult($"Maximum allowed size{_MaxFileSize} bytes !");
                }

            }
            return ValidationResult.Success;
        }
    }
}

