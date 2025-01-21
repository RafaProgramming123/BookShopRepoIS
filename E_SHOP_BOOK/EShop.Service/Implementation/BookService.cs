using EShop.Domain.Domain;
using EShop.Repository.Interface;
using EShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.implementation
{
    public class BookService : IBookService
    {

        private readonly IRepository<Book> _bookRepository;
        public BookService(IRepository<Book> _bookRepository)
        {
            this._bookRepository = _bookRepository;
        }

        public void CreateNewBook(Book b)
        {
            _bookRepository.Insert(b);  
        }

        public void DeleteBook(Guid id)
        {
            var b = _bookRepository.Get(id);
            _bookRepository.Delete(b);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public Book GetDetailsForBook(Guid? id)
        {
            return _bookRepository.GetBookWithAuthor(id);
        }

        public void UpdateExistingBook(Book b)
        {
            _bookRepository.Update(b);
        }
    }
}
