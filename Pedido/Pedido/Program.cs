using Pedido.Entities;
using Pedido.Entities.Enums;

namespace Pedido
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();

            Client client = new Client(name, email, birth);

            Console.WriteLine("Enter order data: ");
            Console.WriteLine("Order Status (PENDING_PAYMENT/PROCESSING/SHIPPED/DELIVERED): ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.WriteLine("How many items to this order? ");
            int quantityItems = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

                 
    
            for (int i = 1; i <= quantityItems; i++)
            {
                Console.WriteLine($"Enter {i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);
                OrderItem item = new OrderItem(productQuantity,productPrice, product);
               
                order.Items.Add(item);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order);
        }
    }
}