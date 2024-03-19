using FluentValidation;

namespace MySOASolution.BLL.DTOs.Validation
{
    public class SamuraiCreateDTOValidation : AbstractValidator<SamuraiCreateDTO>
    {
        public SamuraiCreateDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(255).WithMessage("Name must be at most 255 characters");
            RuleFor(x => x.Origin).NotEmpty().WithMessage("Origin is required").MinimumLength(5).WithMessage("Origin must be at least 5 characters");
        }
    }

    public class QuoteCreateDTOValidator : AbstractValidator<QuoteCreateDTO>
    {
        public QuoteCreateDTOValidator()
        {
            RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required");
            RuleFor(x => x.SamuraiId).GreaterThan(0);
        }
    }

    public class QuoteUpdateDTOValidator : AbstractValidator<QuoteUpdateDTO>
    {
        public QuoteUpdateDTOValidator()
        {
            RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required");
            RuleFor(x => x.SamuraiId).GreaterThan(0);
        }
    }

    public class SamuraiUpdateDTOValidation : AbstractValidator<SamuraiUpdateDTO>
    {
        public SamuraiUpdateDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(255).WithMessage("Name must be at most 255 characters");
            RuleFor(x => x.Origin).NotEmpty().WithMessage("Origin is required").MinimumLength(5).WithMessage("Origin must be at least 5 characters");
        }
    }
}
