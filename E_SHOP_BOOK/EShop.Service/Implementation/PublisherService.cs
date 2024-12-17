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
    public class PublisherService : IPublisherService
    {
        private readonly IRepository<Publisher> _publisherRepository;

        public PublisherService(IRepository<Publisher> _publisherRepository)
        {
            this._publisherRepository = _publisherRepository;
        }

        public void CreateNewPublisher(Publisher p)
        {
           _publisherRepository.Insert(p);
        }

        public void DeletePublisher(Guid id)
        {
            var p = _publisherRepository.Get(id);
            _publisherRepository.Delete(p);
        }

        public List<Publisher> GetAllPublishers()
        {
           return _publisherRepository.GetAll().ToList();
        }

        public Publisher GetDetailsForPublisher(Guid? id)
        {
            var p= _publisherRepository.Get(id);
            return p;
        }

        public void UpdateExistingPublisher(Publisher p)
        {
           _publisherRepository.Update(p);
        }
    }
}
