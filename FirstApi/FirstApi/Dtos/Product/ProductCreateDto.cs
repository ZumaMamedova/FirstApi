using FluentValidation;

namespace FirstApi.Dtos.Product
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public int CategoryId { get; set; }
    }
    public class ProductCreateDtoValidator:AbstractValidator<ProductCreateDto> 
    { 
        public ProductCreateDtoValidator() 
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("bos qoyma")
                .MaximumLength(20).WithMessage("20 den yuxari olmaz");
            RuleFor(p => p.SalePrice)
                .NotNull().WithMessage("bos ola bilmez")
                .GreaterThanOrEqualTo(0).WithMessage("0 dan boyuk olmalidi");
            RuleFor(p => p.CostPrice)
                .NotNull().WithMessage("bos ola bilmez")
                .GreaterThanOrEqualTo(0).WithMessage("0 dan boyuk olmalidi");
            RuleFor(p => p).Custom((p, context) =>
            {
                if (p.CostPrice > p.SalePrice)
                {
                    context.AddFailure("CostPrice", "CostPrice boyuk ola bilmez");
                }
            });
                
        }  
    }
}
