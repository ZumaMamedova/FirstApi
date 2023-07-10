namespace FirstApi.Dtos.Account
{
    public class LoginDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
    //class LoginDtoValidator:AbstractValidator<LoginDto>
    //{
    //    public LoginDtoValidator() 
    //    {
    //        RuleFor(l => l.Username)
    //        .NotEmpty().WithMessage("bos qoyma");
    //    }
    //}
}
