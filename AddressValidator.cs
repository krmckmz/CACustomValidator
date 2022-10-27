public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(address=>address.PostCode).NotNull();
    }
}