namespace ThreatMap.Domain.ValueObjects;

public record Address 
{
    public string Number { get; }
    public string Street { get; }
    public string City { get; }
    public string Country { get; }
    public string ZipCode { get; }

    protected Address()
    {
    }

    public Address(string country, string number, string zipcode, string city, string street)
    {
        Street = street;
        City = city;
        Number = number;
        Country = country;
        ZipCode = zipcode;
    }
}