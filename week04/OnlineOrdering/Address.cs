using System;
using System.Collections.Generic;

public class Address
{
    private string _street;
    private string _city;
    private string _state_province;
    private string _country;


    public Address(string street, string city, string state_province, string country)
    {
        _street = street;
        _city = city;
        _state_province = state_province;
        _country = country;
    }

    public bool FromUSA()
    {
        return new[] { "USA", "US", "U.S.A", "U.S.", "United States of America", "United States" }.Contains(_country);
    }

    public void DisplayAll()
    {
        Console.WriteLine(_street);
        Console.WriteLine($"{_city}, {_state_province}");
        Console.WriteLine(_country);
    }
}

