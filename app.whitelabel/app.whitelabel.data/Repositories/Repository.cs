﻿using app.whitelabel.data.DBConfiguration;
using app.whitelabel.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.whitelabel.data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _context.Add(obj);
            SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAll() => _dbSet.AsNoTracking();


        public IQueryable<TEntity> GetAllBy(Func<TEntity, bool> exp)
        {
            return _dbSet.Where(exp).AsQueryable();
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Remove(Guid id)
        {
            _context.Remove(id);
            SaveChanges();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Update(obj);
            SaveChanges();
        }
    }
}