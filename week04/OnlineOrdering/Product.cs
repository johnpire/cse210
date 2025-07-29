using System;
using System.Collections.Generic;

public class Product
{
    private string _name;
    private string _id;
    private double _price;
    private int _quantity;

    public Product(string name, string id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public void DisplayAll()
    {
        Console.WriteLine($"Name: {_name} | Product ID: {_id} | Price: {_price}$ | Quantity: {_quantity}");
    }
}

