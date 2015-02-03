using System;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Saxo.Models;

namespace Saxo.DAL
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoCollection<Book> collection;

        public BookRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var server = new MongoClient(connectionString).GetServer();
            MongoDatabase dataBase = server.GetDatabase("Saxo");
            collection = dataBase.GetCollection<Book>("Books");
        }

        public Book GetBook(string key)
        {
            try
            {
                var query = Query<Book>.EQ(b => b.Isbn, key);
                var book = collection.FindOne(query);

                return book;
            }
            catch (Exception e)
            {
                throw new Exception("Operation failed", e);
            }
        }

        public void Delete(string key)
        {
            try
            {
                var query = Query<Book>.EQ(b => b.Isbn, key);
                collection.Remove(query);
            }
            catch (Exception e)
            {
                throw new Exception("Operation failed", e);
            }
        }

        public void DeleteAll()
        {
            try
            {
                collection.RemoveAll();
            }
            catch (Exception e)
            {
                throw new Exception("Operation failed", e);
            }
        }

        public void Insert(Book book)
        {
            try
            {
                collection.Insert(book);
            }
            catch (Exception e)
            {
                throw new Exception("Operation failed", e);
            }
        }

        public void Update(Book book)
        {
            try
            {
                collection.Save(book);
            }
            catch (Exception e)
            {
                throw new Exception("Operation failed", e);
            }
        }
    }
}