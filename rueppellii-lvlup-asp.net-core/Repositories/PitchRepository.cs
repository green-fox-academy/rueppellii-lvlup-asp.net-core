using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Models;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Repositories
{
    public class PitchRepository : ICrudRepository<Pitch>
    {
        private readonly LvlUpDbContext context;

        public PitchRepository(LvlUpDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Pitch> GetAll()
        {
            return context.Pitches;
        }

        public Pitch GetById(long id)
        {
            return context.Pitches.Find(id);
        }

        public void Update(Pitch entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        public void Save(Pitch entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
    }
}
