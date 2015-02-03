using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Saxo.DAL;
using Saxo.Flow;
using Saxo.Models;

namespace Saxo
{
    public class Manager
    {
        private readonly FlowBase flow;
        private readonly BookRepository repository;

        public Manager()
        {
            flow = new SaxoFlow();
            repository = new BookRepository();
        }

        public async Task<IEnumerable<Book>> GetBooks(string[] keys)
        {
            var tasks = keys.Select(GetBook).ToArray();
            await Task.WhenAll(tasks);

            return tasks.Select(x => x.Result);
        }

        public async Task<Book> GetBook(string key)
        {
            var book = repository.GetBook(key);
            if (book == null)
            {
                var flowResult = (SaxoFlowResult)await flow.Execute(new RequestInfo(key));
                book = new Book
                {
                    Isbn = flowResult.Isbn,
                    ImageUrl = flowResult.ImageUrl,
                    Label = flowResult.Label,
                    RatingCount = flowResult.RatingCount,
                    Title = flowResult.Title,
                    Url = flowResult.Url,
                    IsChecked = false
                };

                repository.Insert(book);
            }

            return book;
        }

        public void UpdateBookChecked(string key, bool value)
        {
            var book = repository.GetBook(key);
            book.IsChecked = value;
            repository.Update(book);
        }

        public void Delete(string key)
        {
            repository.Delete(key);
        }

        public void DeleteAll()
        {
            repository.DeleteAll();
        }
    }
}