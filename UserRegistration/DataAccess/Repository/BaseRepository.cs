using Microsoft.EntityFrameworkCore;
using UserRegistration.DataAccess.Repository.Interfaces;
using System.Collections.Generic;

namespace UserRegistration.DataAccess.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal UserRegistrationDbContext context;
        internal DbSet<TEntity> dbSet;
        public BaseRepository(UserRegistrationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
            var result = entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            return await context.SaveChangesAsync();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual TEntity GetFirstOrDefault(object id)
        {
            return dbSet.Find(id);
        }

        public virtual async Task<TEntity> GetFirstOrDefaultAsnyc(int id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}
