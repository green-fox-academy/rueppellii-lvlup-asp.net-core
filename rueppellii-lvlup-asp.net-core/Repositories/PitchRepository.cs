﻿using rueppellii_lvlup_asp.net_core.Data;
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


        public void Save(Pitch entity)
        {
            context.Pitches.Add(entity);
            context.SaveChanges();
        }
    }
}