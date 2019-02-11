using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Repositories
{
    public class BadgeRepository : ICrudRepository<Badge>
    {
        private readonly LvlUpDbContext context;

        public BadgeRepository(LvlUpDbContext context)
        {
            this.context = context;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Badge> GetAll()
        {
            throw new NotImplementedException();
        }

        public Badge GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(Badge entity)
        {
            context.Badges.Add(entity);
            context.SaveChanges();
        }

        public void Update(Badge entity)
        {
            throw new NotImplementedException();
        }
    }
}
