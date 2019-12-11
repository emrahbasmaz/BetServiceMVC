using BetService.Repository.Entity;
using BetService.Repository.Interfaces;
using BetService.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BetService.Repository.Services
{
    public class EventsService : IRepository<Events>, IEventsService
    {
        private readonly Repository<Events> repo;
        public EventsService()
        {
            this.repo = new Repository<Events>();
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

        public IEnumerable<Events> GetAll()
        {
            return this.repo.GetAll().OrderBy(x => x.EventId);
        }

        public Events GetById(object Id)
        {
            return this.repo.GetById(Id);
        }

        public void Insert(Events obj)
        {
            this.repo.Insert(obj);
            this.repo.Save();
        }

        public void Save()
        {
            this.repo.Save();
        }

        public void Update(Events obj)
        {
            this.repo.Update(obj);
            this.repo.Save();
        }
    }
}
