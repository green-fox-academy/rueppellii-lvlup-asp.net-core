using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public interface IReadService<T> where T : class
    {
        List<T> GetAll();
        T GetById(long id);
    }
}
