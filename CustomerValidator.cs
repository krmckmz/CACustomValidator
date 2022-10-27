using FluentValidation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Id)
        .GreaterThan(0).WithMessage("Id alanı 0'dan büyük olmalıdır.");

        RuleFor(customer => customer.Email)
        .EmailAddress()
        .WithMessage("Geçerli bir e-posta değeri giriniz!").When(i => !string.IsNullOrEmpty(i.Email));

        RuleFor(customer => customer.Name)
        .NotEmpty().WithMessage("İsim alanı boş geçilemez!")
        .Length(5,20).WithMessage("İsim alanı 5 ile 20 karakter arasında olmalıdır!");

        RuleFor(customer => customer.Password)
        .NotEmpty().WithMessage("Parola alanı boş geçilemez!")
        // .Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$")
        .Must(IsPasswordValid).WithMessage("Parolanız en az sekiz karakter , en az bir harf ve bir sayı içermelidir!");       

        RuleFor(customer => customer.Address).SetValidator(new AddressValidator());
    }

    private bool IsPasswordValid(string argument)
    {
      Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
      return regex.IsMatch(argument);
    }
}