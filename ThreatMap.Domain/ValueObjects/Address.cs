namespace ThreatMap.Domain.ValueObjects;

public record Address 
{
    public string Number { get; }
    public string Street { get; }
    public string City { get; }
    public string Country { get; }
    public string ZipCode { get; }

    private Address(string number, string street, string city, string country, string zipCode)
    {
        Number = number;
        Street = street;
        City = city;
        Country = country;
        ZipCode = zipCode;
    }

    public static Address Create(string country, string number, string zipcode, string city, string street, string zipCode)
    {
        return new Address(number, street, city, country, zipcode);
    }
}