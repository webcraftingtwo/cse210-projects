using System;

class Program
{
    static void Main(string[] args)
    {
        // --- ORDER 1 (USA) ---
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "L100", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M200", 25.50, 2));

        Console.WriteLine("-----------------------------------");
        Console.WriteLine("ORDER 1 DETAILS:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotalCost():0.00}");


        // --- ORDER 2 (International) ---
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Smartphone", "P500", 800.00, 1));
        order2.AddProduct(new Product("Case", "C123", 15.00, 3));
        order2.AddProduct(new Product("Charger", "CH99", 30.00, 1));

        Console.WriteLine("\n-----------------------------------");
        Console.WriteLine("ORDER 2 DETAILS:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.CalculateTotalCost():0.00}");
        Console.WriteLine("-----------------------------------");
    }
}
