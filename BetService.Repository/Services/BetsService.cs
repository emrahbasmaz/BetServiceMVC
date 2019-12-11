using BetService.Repository.Entity;
using BetService.Repository.Interfaces;
using BetService.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BetService.Repository.Services
{
    public class BetsService : IRepository<Bets>, IBetsService
    {
        private readonly Repository<Bets> repo;
        public BetsService()
        {
            this.repo = new Repository<Bets>();
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

        public IEnumerable<Bets> GetAll()
        {
            return this.repo.GetAll().OrderBy(x => x.BetId);
        }

        public Bets GetById(object Id)
        {
            return this.repo.GetById(Id);
        }

        public void Insert(Bets obj)
        {
            this.repo.Insert(obj);
            this.repo.Save();
        }

        public void Save()
        {
            this.repo.Save();
        }

        public void Update(Bets obj)
        {
            this.repo.Update(obj);
            this.repo.Save();
        }
    }
}
