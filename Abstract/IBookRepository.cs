using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IBookRepository
    {
        IEnumerable<Login> Logins { get; }
        IEnumerable<Book> Books { get; }
        void SaveBook(Book book);
        void Delete(Book book);
        void Save(Login login);
        void DeleteLogin(Login login);
    }
}
