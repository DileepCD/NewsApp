﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Auth.Data
{
    public abstract class RepositoryBase<T> where T : class, new()
    {
        private readonly NewsDbContext dbContext;
        private readonly DbSet<T> dbSet;
        protected RepositoryBase(NewsDbContext context)
        {
            this.dbContext = context;
            this.dbSet = this.dbContext.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return this.dbSet.Find(id);
        }
        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }
        public virtual T Add(T entity)
        {
            this.dbSet.Add(entity);
            return entity;
        }
        public virtual void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
    public interface IRepositoryBase<T>
    {
        T GetById(int id);
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void SaveChanges();
    }
}
