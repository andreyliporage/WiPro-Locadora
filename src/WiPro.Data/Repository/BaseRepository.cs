using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WiPro.Data.Context;
using WiPro.Domain.Entities;
using WiPro.Domain.Interfaces;

namespace WiPro.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly WiProContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(WiProContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }

                _dataset.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(e => e.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(entity.Id));
                if (result == null) return null;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                throw;
            }

            return entity;
        }
    }
}