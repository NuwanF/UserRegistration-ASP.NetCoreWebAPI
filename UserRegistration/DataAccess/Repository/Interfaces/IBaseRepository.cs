namespace UserRegistration.DataAccess.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entityToUpdate);
        Task<TEntity> UpdateAsync(TEntity entity);
        void Delete(TEntity entityToDelete);
        Task<int> DeleteAsync(TEntity entity);
        IEnumerable<TEntity> GetAll();
        Task<ICollection<TEntity>> GetAllAsync();
        TEntity GetFirstOrDefault(object id);
        Task<TEntity> GetFirstOrDefaultAsnyc(int id);
    }

}
