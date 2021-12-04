namespace ThreatMap.Domain.ValueObjects;

public record Address 
{
    public string Number { get; }
    public string Street { get; }
    public string City { get; }
    public string ZipCode { get; }

    private Address(string number, string street, string city, string zipCode)
    {
        Number = number;
        Street = street;
        City = city;
        ZipCode = zipCode;
    }

    public static Address Create(string number, string street, string city)
    {
        return new Address(number, street, city, null);
    }
    
    public static Address Create(string number, string street, string city, string zipcode)
    {
        return new Address(number, street, city, zipcode);
    }
}