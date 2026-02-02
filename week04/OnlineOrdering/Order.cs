using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        
        // Sum up all products
        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }

        // Add shipping cost based on location
        // $5 for USA, $35 for International
        int shippingCost = _customer.LivesInUSA() ? 5 : 35;
        total += shippingCost;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in _products)
        {
            label += $"- {p.GetName()} (ID: {p.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"{_customer.GetName()}\n";
        label += _customer.GetAddressText();
        return label;
    }
}
