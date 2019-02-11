using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public interface ICrudService<T, U> where T : class where U : class
    {
        IEnumerable<T> GetAll();
        void Save(T dto);
    }
}
