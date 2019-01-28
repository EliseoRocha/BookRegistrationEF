using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEF
{
    static class BookDb
    {
        public static List<Book> GetAllBooks()
        {
            //Create a context object to
            //connect and query the DB
            BookRegContext context = new BookRegContext();

            //Use LINQ  to query the database using the context
            //LINQ Query Syntax
            //List<Book> allBooks =
            //    (from b in context.Book
            //        //where b.Price <= 50
            //    select b).ToList();

            //Does the same as above
            //LINQ Method Syntax
            List<Book> allBooks = context.Book.ToList();

            return allBooks;
        }

        public static void AddBook(Book b)
        {
            //Database Context
            BookRegContext context = new BookRegContext();

            //create insert query
            //Adds insert to a list of pending queries
            context.Book.Add(b);

            //Executes all pending Insert/Update/Delete
            context.SaveChanges();
        }
    }
}
