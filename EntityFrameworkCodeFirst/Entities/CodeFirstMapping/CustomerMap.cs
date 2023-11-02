using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.Entities.CodeFirstMapping
{
    public class CustomerMap: EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.HasKey(c => c.CustomerId);
            this.Property(c => c.CustomerId).IsRequired().HasMaxLength(5);
            this.Property(c => c.ContactName).HasMaxLength(30).IsRequired();
            this.Property(c => c.CompanyName).HasMaxLength(40).IsRequired();
            this.Property(c => c.City).HasMaxLength(15).IsRequired();
            this.Property(c => c.Country).HasMaxLength(15).IsRequired();
            ToTable("Customers");

            this.Property(c => c.CustomerId).HasColumnName("CustomerID");
            this.Property(c => c.ContactName).HasColumnName("ContactName");
            this.Property(c => c.CompanyName).HasColumnName("CompanyName");
            this.Property(c => c.City).HasColumnName("City");
            this.Property(c => c.Country).HasColumnName("Country");

        }
    }
}
