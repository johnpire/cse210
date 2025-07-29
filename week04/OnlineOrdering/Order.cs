using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void GetTotalCost()
    {
        double shippingCost = 0;
        double totalCost = 0;
        foreach (Product product in _products)
        {
            double productCost = product.GetTotalCost();
            totalCost += productCost;
        }
        if (_customer.FromUSA())
        {
            shippingCost = 5;
            totalCost += shippingCost;
        }
        else
        {
            shippingCost = 35;
            totalCost += shippingCost;
        }
        Console.WriteLine($"Total Cost: {totalCost.ToString("F2")}$ | Shipping Cost: {shippingCost}$");
    }

    public void AddPackingLabel(Product product)
    {
        _products.Add(product);
    }

    public void GetShippingLabel()
    {
        _customer.DisplayAll();
    }

    public void DisplayOrders()
    {
        foreach (Product product in _products)
        {
            product.DisplayAll();
        }
    }
}

