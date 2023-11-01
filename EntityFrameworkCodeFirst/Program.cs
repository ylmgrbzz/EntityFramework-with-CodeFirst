using EntityFrameworkCodeFirst.Contexts;
using EntityFrameworkCodeFirst.Entities;

namespace EntityFrameworkCodeFirst
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new NorthwindContext())
            {
                Order order = context.Orders.Find(1);
                Console.WriteLine($"{order.OrderId} {order.CustomerId} {order.Customer.ContactName}");
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        private static void RemoveOrder()
        {
            using (var context = new NorthwindContext())
            {
                Customer customer = context.Customers.Find("ALFKI");
                customer.ContactName
                    = "Maria Anders";
                context.SaveChanges();
            }
        }

        private static void FindCustomer()
        {
            using (var context = new NorthwindContext())
            {
                Customer customer = context.Customers.Find("ALFKI");
                customer.Orders.Add(new Order
                {
                    OrderId = 1,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(7),
                    ShipCity = "Berlin",
                    ShipCountry = "Germany"
                });
                context.SaveChanges();
            }
        }

        private static void AddCustomer()
        {
            using (var context = new NorthwindContext())
            {
                var customer = new Customer
                {
                    CustomerId = "ALFKI",
                    ContactName = "Maria Anders",
                    CompanyName = "Alfreds Futterkiste",
                    Country = "Germany"
                };
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        private static void ConnectDbSet()
        {
            using (var context = new NorthwindContext())
            {
                var customers = context.Customers.ToList();
                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.CustomerId} {customer.ContactName}");
                }
            }
        }
    }
}