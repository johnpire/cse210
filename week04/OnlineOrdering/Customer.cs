using System;
using System.Collections.Generic;

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool FromUSA()
    {
        return _address.FromUSA();
    }

    public void DisplayAll()
    {
        Console.WriteLine(_name);
        _address.DisplayAll();
    }
}

