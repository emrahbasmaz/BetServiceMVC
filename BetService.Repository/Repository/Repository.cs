﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BetService.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private BetDbContext db;
        private bool shareContext = false;
        private readonly DbSet<T> dbSet;

        public Repository()
        {
            db = new BetDbContext();
            dbSet = db.Set<T>();
            shareContext = true;
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(object Id)
        {
            return dbSet.Find(Id);
        }
        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }
        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object Id)
        {
            T getObjById = dbSet.Find(Id);
            dbSet.Remove(getObjById);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }

        public void Dispose()
        {
            if (shareContext && (db != null))
                db.Dispose();
        }
    }
}
