using System;

class Program
{
    static void Main(string[] args)
    {
        Address Customer1Address = new Address("San Vicente", "Baguio City", "Benguet", "Philippines");
        Customer Customer1 = new Customer("John", Customer1Address);
        Order Order1 = new Order(Customer1);
        Order1.AddPackingLabel(new Product("ABC Headphones v12", "WM-1034", 52.21, 1));
        Order1.AddPackingLabel(new Product("ABC Mechanical Keyboard A3", "KB-2078", 87.25, 1));
        Order1.AddPackingLabel(new Product("XYZ Rodlight 10m", "UC-3102", 52.36, 10));

        Address Customer2Address = new Address("742 Evergreen Terrace", "Springfield", "Illinois", "USA");
        Customer Customer2 = new Customer("Carlo", Customer2Address);
        Order Order2 = new Order(Customer2);
        Order2.AddPackingLabel(new Product("Organic Brown Rice", "GR-1021", 3.49, 25));
        Order2.AddPackingLabel(new Product("Herbal Soap Bar", "PC-2045", 1.99, 50));
        Order2.AddPackingLabel(new Product("Notebook - A5 Lined", "ST-3310", 2.75, 100));

        List<Order> orders = new List<Order> { Order1, Order2 };
        int i = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"Order {i++}");
            order.GetShippingLabel();
            order.DisplayOrders();
            order.GetTotalCost();
            Console.WriteLine();
        }
    }
}