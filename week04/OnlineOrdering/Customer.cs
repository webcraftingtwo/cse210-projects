using System;

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Checks if the customer lives in the USA (by asking the Address object)
    public bool LivesInUSA()
    {
        return _address.IsUSA();
    }

    public string GetName()
    {
        return _name;
    }

    public string GetAddressText()
    {
        return _address.GetDisplayText();
    }
}
