using System.ComponentModel.DataAnnotations;

namespace GameStore.attribute
{
    public class AllowedExtentionAttribute : ValidationAttribute
    {
        private readonly string _AllowExtention;
        public AllowedExtentionAttribute(string AllowExtention)
        {
            _AllowExtention = AllowExtention;
        }
        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null) 
            { 
             var extention = Path.GetExtension(file.FileName);
             var isallowed = _AllowExtention.Split(",").Contains(extention,
                 StringComparer.OrdinalIgnoreCase);
                if (!isallowed) 
                {
                    return new ValidationResult($"only{_AllowExtention} are allowed !");
                }

            }
            return ValidationResult.Success;
        }
    }
}
