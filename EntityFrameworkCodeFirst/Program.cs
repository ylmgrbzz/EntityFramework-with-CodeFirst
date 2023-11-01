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
                //RemoveOrder();
                //UpdateOrder();
                //FindCustomer();
                //AddCustomer();
            }
        }

        private static void OrderBy()
        {
            using (var context = new NorthwindContext())
            {
                var result = from c in context.Customers
                             orderby c.Country, c.City
                             select c;
                foreach (var customer in result)
                {
                    Console.WriteLine($"{customer.Country} {customer.City}");
                }
            }
        }

        private static void GroupMoreColumn()
        {
            using (var context = new NorthwindContext())
            {
                var result = from c in context.Customers
                             group c by new { c.Country, c.City } into g
                             select new
                             {
                                 Country = g.Key.Country,
                                 City = g.Key.City,
                                 Count = g.Count()
                             };

                foreach (var group in result)
                {
                    foreach (var customer in result)
                    {
                        Console.WriteLine($"{group.Country} {group.City} {group.Count}");
                    }
                }
            }
        }

        private static void Group()
        {
            using (var context = new NorthwindContext())
            {
                var result = from c in context.Customers
                             group c by c.Country into g
                             select g;
                foreach (var group in result)
                {
                    Console.WriteLine(group.Key);
                    foreach (var customer in group)
                    {
                        Console.WriteLine($"  {customer.CustomerId} {customer.ContactName}");
                    }
                }
            }
        }

        private static void Update()
        {
            using (var context = new NorthwindContext())
            {
                List<Customer> result = (from c in context.Customers
                                         where c.Country == "Germany"
                                         select c).ToList();
            }
        }

        private static void RemoveOrder()
        {
            using (var context = new NorthwindContext())
            {
                Order order = context.Orders.Find(1);
                Console.WriteLine($"{order.OrderId} {order.CustomerId} {order.Customer.ContactName}");
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        private static void UpdateOrder()
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