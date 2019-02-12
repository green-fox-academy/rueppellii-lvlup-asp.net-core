using Microsoft.EntityFrameworkCore;
using rueppellii_lvlup_asp.net_core.Data;
using rueppellii_lvlup_asp.net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public Pitch GetById(long id)
        {
            return context.Pitches.Find(id);
        }

        public void Save(Pitch entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Pitch pitch)
        {
            context.Update(pitch);
            context.SaveChanges();
        }
    }
}
