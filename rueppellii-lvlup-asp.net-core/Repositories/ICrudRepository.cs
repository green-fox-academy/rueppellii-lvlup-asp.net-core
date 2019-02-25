using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Repositories
{
    public interface ICrudRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Save(T entity);
    }
}
