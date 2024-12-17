using EShop.Domain.Domain;
using EShop.Repository.Implementation;
using EShop.Repository.Interface;
using EShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> _authorRepository)
        {
            this._authorRepository = _authorRepository;
           
        }
        public void CreateNewAuthor(Author a)
        {
           _authorRepository.Insert(a);

        }

        public void DeleteAuthor(Guid id)
        {
            var a = _authorRepository.Get(id);
                _authorRepository.Delete(a);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll().ToList();
        }

        public Author GetDetailsForAuthor(Guid? id)
        {
          var a=_authorRepository.Get(id);
            return a;
            
        }

        public void UpdateExistingAuthor(Author a)
        {
            _authorRepository.Update(a);
        }
    }
}
