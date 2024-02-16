using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZefixTest.Interfaces.Repositories;
using ZefixTest.Models.Context;

namespace ZefixTest.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ZefixContext _zefixContext;

        public BaseRepository(ZefixContext zefixContext)
        {
            _zefixContext = zefixContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _zefixContext.Set<T>().AddAsync(entity);
            await _zefixContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _zefixContext.Set<T>().Remove(entity);
            await _zefixContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _zefixContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _zefixContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _zefixContext.Update(entity);
            await _zefixContext.SaveChangesAsync();
        }
    }
}
