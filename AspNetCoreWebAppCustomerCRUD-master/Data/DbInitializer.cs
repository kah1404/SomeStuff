using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesContacts.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            var cust = new Customer[]
            {
                new Customer {Name = "Kjell"},
                new Customer {Name = "Olaf"},
                new Customer {Name = "Odd"},
                new Customer {Name = "Åsmund"},
                new Customer {Name = "Roy"},

            };

            foreach (Customer s in cust)
            {
                context.Customers.Add(s);
            }
            context.SaveChanges();
        }
    }
}
