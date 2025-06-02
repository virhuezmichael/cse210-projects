using System;

class Program
{
    static void Main(string[] args)
    {
        
        Address addr1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer cust1 = new Customer("John Smith", addr1);

        Address addr2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Emily Johnson", addr2);

       
        Product prod1 = new Product("Laptop", "LP1001", 899.99m, 1);
        Product prod2 = new Product("Mouse", "MS2002", 25.50m, 2);
        Product prod3 = new Product("Keyboard", "KB3003", 45.00m, 1);

        Product prod4 = new Product("Monitor", "MN4004", 199.99m, 2);
        Product prod5 = new Product("USB Cable", "US5005", 10.00m, 3);

      
        Order order1 = new Order(cust1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);
        order1.AddProduct(prod3);

        Order order2 = new Order(cust2);
        order2.AddProduct(prod4);
        order2.AddProduct(prod5);

       
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}