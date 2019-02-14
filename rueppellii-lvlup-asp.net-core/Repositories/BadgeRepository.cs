using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Models;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Repositories
{
    public class BadgeRepository : ICrudRepository<Badge>
    {
        private readonly LvlUpDbContext context;

        public BadgeRepository(LvlUpDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Badge> GetAll()
        {
            return context.Badges;
        }

        public void Save(Badge entity)
        {
            context.Badges.Add(entity);
            context.SaveChanges();
        }
    }
}
