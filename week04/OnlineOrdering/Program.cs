using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System");
        Console.WriteLine("======================\n");

        // Create addresses
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Address address3 = new Address("789 Oak St", "London", "England", "UK");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Marie Curie", address2);
        Customer customer3 = new Customer("David Johnson", address3);

        // Create products
        Product product1 = new Product("Laptop", "P001", 899.99, 1);
        Product product2 = new Product("Mouse", "P002", 25.50, 2);
        Product product3 = new Product("Keyboard", "P003", 75.00, 1);
        Product product4 = new Product("Monitor", "P004", 299.99, 1);
        Product product5 = new Product("Headphones", "P005", 150.00, 1);

        // Create first order (USA customer)
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product5);

        // Create second order (International customer)
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product2);

        // Create third order (International customer)
        Order order3 = new Order(customer3);
        order3.AddProduct(product1);
        order3.AddProduct(product4);
        order3.AddProduct(product5);

        // Display order information
        DisplayOrder(order1);
        DisplayOrder(order2);
        DisplayOrder(order3);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("===================================");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}");
        Console.WriteLine("===================================\n");
    }
}