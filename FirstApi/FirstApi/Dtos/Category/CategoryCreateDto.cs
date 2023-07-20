using FluentValidation;

namespace FirstApi.Dtos.Category
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }

    }
    public class CategoryCreateDtoValidator:AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("bos qoyma")
                .MaximumLength(20)
                .WithMessage("20den cox ola bilmez");
        }
    }
}
