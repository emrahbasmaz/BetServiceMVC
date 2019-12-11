using BetService.Repository.Entity;
using BetService.Repository.Interfaces;
using BetService.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BetService.Repository.Services
{
    public class PlayersService : IRepository<Players>, IPlayersService
    {
        private readonly Repository<Players> repo;
        public PlayersService()
        {
            this.repo = new Repository<Players>();
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

        public IEnumerable<Players> GetAll()
        {
            return this.repo.GetAll().OrderBy(x => x.PlayerId);
        }

        public Players GetById(object Id)
        {
            return this.repo.GetById(Id);
        }

        public void Insert(Players obj)
        {
            this.repo.Insert(obj);
            this.repo.Save();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Players obj)
        {
            this.repo.Update(obj);
            this.repo.Save();
        }
    }
}
