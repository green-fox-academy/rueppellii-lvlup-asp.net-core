using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Models;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Repositories
{
    public class BadgeRespository : ICrudRepository<Badge>
    {
        private readonly LvlUpDbContext context;

        public BadgeRespository(LvlUpDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Badge> GetAll()
        {
            return context.Badges;
        }

        public Badge GetById(long id)
        {
            return context.Badges.Find(id);
        }

        public void Save(Badge entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Badge entity)
        {
            context.Badges.Update(entity);
            context.SaveChanges();
        }
    }
}
