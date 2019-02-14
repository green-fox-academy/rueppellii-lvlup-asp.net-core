using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Services
{
    /// <summary>
    /// U = dto
    /// T = entity
    /// Can be extended with get methods by different properties
    /// </summary>
    public interface IReadService<U, T> where U : class where T : class
    {
        IEnumerable<U> GetAll(); //gets all the entities from the repo, returns a JSON list
    }
}
