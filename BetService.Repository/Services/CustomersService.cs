using System;
using System.Collections.Generic;
using System.Linq;
using BetService.Repository.Entity;
using BetService.Repository.Interfaces;
using BetService.Repository.Repository;

namespace BetService.Repository.Services
{
    public class CustomersService : IRepository<Customers>, ICustomersService
    {
        private readonly Repository<Customers> repo;
        public CustomersService()
        {
            this.repo = new Repository<Customers>();
        }

        public void Delete(object Id)
        {
            this.repo.Delete(Id);
            this.repo.Save();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customers> GetAll()
        {
            return this.repo.GetAll().OrderBy(x => x.CustomerID);
        }

        public Customers GetById(object Id)
        {
            return this.repo.GetById(Id);
        }

        public void Insert(Customers obj)
        {
            this.repo.Insert(obj);
            this.repo.Save();
        }

        public void Save()
        {
            this.repo.Save();
        }

        public void Update(Customers obj)
        {
            this.repo.Update(obj);
            this.repo.Save();
        }
    }
}
