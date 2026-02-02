using System;

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // Returns true if the address is in the USA
    public bool IsUSA()
    {
        return _country.ToLower() == "usa";
    }

    // Returns a string formatted for the label
    public string GetDisplayText()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}
