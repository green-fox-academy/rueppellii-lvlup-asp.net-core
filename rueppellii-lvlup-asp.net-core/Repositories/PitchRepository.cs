using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rueppellii_lvlup_asp.net_core.Repositories
{
    public class PitchRepository : ICrudRepository<Pitch>
    {
        private readonly LvlUpDbContext context;

        public PitchRepository(LvlUpDbContext context)
        {
            this.context = context;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pitch> GetAll()
        {
            return context.Pitches.ToList();
        }

        public Pitch GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(Pitch entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Pitch entity)
        {
            throw new NotImplementedException();
        }
    }
}
