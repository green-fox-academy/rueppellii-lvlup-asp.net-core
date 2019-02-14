 using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Repositories
{
    public interface ICrudRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        void Save(T entity);
        void Update(T entity);
        void Delete(long id);
    }
}
