using Saxo.Models;

namespace Saxo.DAL
{
    interface IBookRepository
    {
        Book GetBook(string key);
        void Delete(string key);
        void Insert(Book book);
        void Update(Book book);
    }
}