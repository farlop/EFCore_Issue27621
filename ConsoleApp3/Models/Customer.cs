namespace ConsoleApp3.Models;

public class Customer
{
    public int Id { get; private set; }

    public string Code { get; private set; }

    public string Description { get; private set; }


    public Customer(string code, string description)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public void SetCode(string code) => Code = code ?? throw new ArgumentNullException(nameof(code));

    public void SetDescription(string description) => Description = description ?? throw new ArgumentNullException(nameof(description));
    
}
