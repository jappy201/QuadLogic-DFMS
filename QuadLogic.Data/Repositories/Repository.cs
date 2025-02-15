﻿using Microsoft.EntityFrameworkCore;
using QuadLogic.Core.Interfaces;
using QuadLogic.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuadLogic.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly QuadLogicDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(QuadLogicDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
