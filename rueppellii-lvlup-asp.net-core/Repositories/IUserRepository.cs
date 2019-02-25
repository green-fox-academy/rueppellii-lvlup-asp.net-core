using rueppellii_lvlup_asp.net_core.Models;

namespace rueppellii_lvlup_asp.net_core.Repositories
{
    public interface IUserRepository : ICrudRepository<User>
    {
        bool DoesEntityExistByProperty(string property, string propertyValue);
    }
}
