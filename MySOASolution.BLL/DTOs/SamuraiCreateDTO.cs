using FluentValidation;

namespace MySOASolution.BLL.DTOs
{
    public class SamuraiCreateDTO
    {
        public string? Name { get; set; }

        public string? Origin { get; set; }
    }

    public class SamuraiCreateDTOValidation : AbstractValidator<SamuraiCreateDTO>
    {
        public SamuraiCreateDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(255).WithMessage("Name must be at most 255 characters");
            RuleFor(x => x.Origin).NotEmpty().WithMessage("Origin is required").MinimumLength(5).WithMessage("Origin must be at least 5 characters");
        }
    }
}
