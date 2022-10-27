public class Customer
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Password { get; set; }
  public string Email { get; set; }
  public Address Address { get; set; }

  public bool ValidateCustomer(Customer customer)
  {
     CustomerValidator customerValidator = new CustomerValidator();
     ValidationResult validationResult = customerValidator.Validate(customer);

     return validationResult.IsValid;
  }
}