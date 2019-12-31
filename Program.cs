using System;


namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Intialize services
            OrderService orderService = new OrderService();
            BillingService billingService = new BillingService();
            ShippingService shippingService = new ShippingService();

            // Register event listeners
            orderService.OrderCreated += billingService.ProcessPayment;
            orderService.OrderCreated += shippingService.PrepareShipping;

            // Trigger an event
            orderService.CreateOrder();

            Console.ReadKey();
        }
    }

    class OrderService
    {
        // This event/even handler is a delegate, 
        // like a function takes (object source, EventArgs args)
        // That's why it's public.
        // 
        // Equivalent to:
        /*
          public delegate void OrderCreatedEventHandler(object source, EventArgs args);

          public event OrderCreatedEventHandler<OrderInfo> OrderCreated;
        */
        public event EventHandler<OrderInfo> OrderCreated;

        public void CreateOrder()
        {
            var orderInfo = new OrderInfo
            {
                OrderId = "order-123",
                Quantity = 100,
                Price = 98.99
            };

            Console.WriteLine("Order created...");

            OnCreateOrder(orderInfo);
        }

        /*
           This method has to be:
           protected virtual void OnSomething()      
        */
        protected virtual void OnCreateOrder(OrderInfo orderInfo)
        {
            if (OrderCreated == null)
            {
                Console.WriteLine("No event listeners registered!");
                return;
            }

            Console.WriteLine("Notify event listeners...");
            OrderCreated(this, orderInfo);
        }
    }

    class BillingService
    {
        public void ProcessPayment(object source, OrderInfo orderInfo)
        {
            Console.WriteLine("Start billing process...");
            Console.WriteLine($"Bill Payment: {orderInfo.ToString()}");
        }
    }

    class ShippingService
    {
        public void PrepareShipping(object source, OrderInfo orderInfo)
        {
            Console.WriteLine("Prepare shipping...");
            Console.WriteLine($"Ship: {orderInfo.ToString()}");
        }
    }

    class OrderInfo : EventArgs
    {
        public string OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public new string ToString()
        {
            string str = $"OrderInfo [OrderId: {this.OrderId}, Quantity: {this.Quantity}, Price: {this.Price}]";
            return str;
        }
    }

}
