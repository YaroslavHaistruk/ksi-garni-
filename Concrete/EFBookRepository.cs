using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFBookRepository : IBookRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Book> Books
        {
            get { return context.Books; }
        }
        public IEnumerable<Login> Logins
        {
            get { return context.Logins; }
        }

        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
            {
                context.Books.Add(book);
            }
            else
            {
                Book dbEntry = context.Books.Find(book.BookId);
                if (dbEntry != null)
                {
                    dbEntry.Name = book.Name;
                    dbEntry.Author = book.Author;
                    dbEntry.Description = book.Description;
                    dbEntry.Genre = book.Genre;
                    dbEntry.Price = book.Price;
                }
            }
            context.SaveChanges();
        }
        public void Delete(Book book)
        {
            if (book.BookId == 0)
            {
                context.Books.Remove(book);
            }
            else
            {
                Book dbEntry = context.Books.Find(book.BookId);
                if (dbEntry != null)
                {
                    context.Books.Remove(book);
                }
            }
            context.SaveChanges();
        }
        public void Save(Login login)
        {
            if (login.LoginId == 0)
            {
                context.Logins.Add(login);
            }
            else
            {
                Login dbEntry = context.Logins.Find(login.LoginId);
                if (dbEntry != null)
                {
                    dbEntry.Imie = login.Imie;
                    dbEntry.Pass = login.Pass;
  
                }
            }
            context.SaveChanges();
        }
        public void DeleteLogin(Login login)
        {
            if (login.LoginId == 0)
            {
                context.Logins.Remove(login);
            }
            else
            {
                Login dbEntry = context.Logins.Find(login.LoginId);
                if (dbEntry != null)
                {
                    context.Logins.Remove(login);
                }
            }
            context.SaveChanges();
        }
    }
}
