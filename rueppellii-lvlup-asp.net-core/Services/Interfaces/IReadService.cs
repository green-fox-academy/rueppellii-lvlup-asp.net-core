using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Services.Interfaces

{
    public interface IReadService<U> where U : class
    {
        IEnumerable<U> GetAll();
    }
}
