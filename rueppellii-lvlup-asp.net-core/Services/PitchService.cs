using AutoMapper;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public class PitchService
    {
        private readonly IMapper mapper;
        private readonly ICrudRepository<Pitch> pitchRepository;

        public PitchService(ICrudRepository<Pitch> pitchRepository, IMapper mapper)
        {
            this.pitchRepository = pitchRepository;
            this.mapper = mapper;
        }

        public void Update(PutPitchDto updatedPitchDto, long id)
        {
            var pitchToUpdate = pitchRepository.GetById(id);
            var updatedPitch = mapper.Map<PutPitchDto, Pitch>(updatedPitchDto, pitchToUpdate);
            pitchRepository.Update(updatedPitch);
        }

        public Pitch GetById(long id)
        {
            return pitchRepository.GetById(id);
        }
    }
}
