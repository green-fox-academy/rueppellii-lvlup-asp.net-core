using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public interface IUpdateService<U> where U : class
    {
        void Update(long id, U entity);
    }
}
