﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext RepositoryDbContext;
        protected DbSet<TEntity> RepositoryDbSet;

        // ctor --- lühend et luua constructor
        public EFRepository(DbContext dataContext)
        {
            RepositoryDbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            RepositoryDbSet = dataContext.Set<TEntity>();
        }
        public IEnumerable<TEntity> All()
        {
            return RepositoryDbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await RepositoryDbSet.ToListAsync();
        }

        public TEntity Find(params object[] id)
        {
            return RepositoryDbSet.Find(id);
        }

        public async Task<TEntity> FindAsync(params object[] id)
        {
            return await RepositoryDbSet.FindAsync(id);
        }

        public void Add(TEntity entity)
        {
            RepositoryDbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await RepositoryDbSet.AddAsync(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return RepositoryDbSet.Update(entity).Entity;
        }

        public void Remove(TEntity entity)
        {
            RepositoryDbSet.Remove(entity);
        }

        public void Remove(params object[] id)
        {
            RepositoryDbSet.Remove(Find(id));
        }
    }
}
