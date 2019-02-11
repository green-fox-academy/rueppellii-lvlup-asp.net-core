using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Models;
using System;
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

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Badge> GetAll()
        {
            return context.Badges;
        }

        public Badge GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(Badge entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Badge entity)
        {
            throw new NotImplementedException();
        }
    }
}
