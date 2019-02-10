using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEF
{
    static class CustomerDb
    {
        public static List<Customer> GetCustomers()
        {
            BookRegContext context = new BookRegContext();

            //SELECT * FROM Customers
            List<Customer> allCustomers = (from c in context.Customer
                               select c).ToList();

            return allCustomers;
        }

        public static Customer AddCustomer(Customer c)
        {
            BookRegContext context = new BookRegContext();

            context.Customer.Add(c);

            context.SaveChanges();

            return c;
        }

        public static void DeleteCustomer(Customer c)
        {

            BookRegContext context = new BookRegContext();

            //Telling Entity Framework (EF) that the customer
            //exists, and we want it removed from the DB
            //context.Customer.Attach(c);
            //context.Customer.Remove(c);

            //ALTERNATIVE
            context.Entry(c).State = EntityState.Deleted;

            context.SaveChanges();
        }

        public static Customer Update(Customer c)
        {
            BookRegContext context = new BookRegContext();

            context.Entry(c).State = EntityState.Modified;

            context.SaveChanges();

            return c;
        }
    }
}
