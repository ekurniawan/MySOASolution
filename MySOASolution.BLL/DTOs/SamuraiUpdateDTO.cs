using FluentValidation;

namespace MySOASolution.BLL.DTOs
{
    public class SamuraiUpdateDTO
    {
        public int SamuraiId { get; set; }

        public string? Name { get; set; }

        public string? Origin { get; set; }
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
