namespace EntityFrameworkCodeFirst.Entities
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Order> Orders { get; set; }
    }
}