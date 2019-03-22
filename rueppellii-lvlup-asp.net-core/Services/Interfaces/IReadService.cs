using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Services.Interfaces

{
    public interface IReadService<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
