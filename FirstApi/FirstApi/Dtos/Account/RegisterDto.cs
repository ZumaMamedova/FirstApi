namespace FirstApi.Dtos.Account
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
    //public class RegisterDtoValidator:AbstractValidator<RegisterDto> 
    //{
    //    public RegisterDtoValidator() 
    //    {
    //        RuleFor(l => l.Username)
    //        .NotEmpty().WithMessage("bos qoyma")
    //        .MaximumLength(20).WithMessage("20den yuxari olmaz");

    //    }
    //}    
}
