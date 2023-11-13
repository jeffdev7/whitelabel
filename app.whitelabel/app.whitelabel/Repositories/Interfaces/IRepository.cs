namespace app.whitelabel.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllBy(Func<TEntity, bool> exp);
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}