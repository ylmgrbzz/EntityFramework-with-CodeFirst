


using EntityFrameworkCodeFirst.Contexts;
using EntityFrameworkCodeFirst.Entities;
using System.Runtime.CompilerServices;

namespace EntityFrameworkCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new NorthwindContext())
            {
               Customer customer = context.Customers.Find("ALFKI");
               customer.Orders.Add(new Order
               {
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
