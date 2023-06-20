namespace Stage2TechincalTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Example
            Order order = new Order
            {
                IsRushOrder = false,
                OrderType = OrderType.Repair,
                IsNewCustomer = false,
                IsLargeOrder = true
            };

            OrderProcessor orderProcessor = new OrderProcessor();
            OrderStatus status = orderProcessor.ProcessOrder(order);
            Console.WriteLine("Order Status: " + status);
        }
    }
}

