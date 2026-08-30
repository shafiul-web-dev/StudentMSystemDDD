using FluentValidation;

namespace StudentMSystem.Handler.Services
{
    public class ValidationService<T>
    {
        private readonly IValidator<T> _validator;
        public ValidationService(IValidator<T> validator)
        {
            _validator = validator;
        }
        public async Task  ValidateAsync(T request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }
        }
    }
} 