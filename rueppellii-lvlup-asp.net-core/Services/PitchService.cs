using AutoMapper;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;
using rueppellii_lvlup_asp.net_core.Services.Interfaces;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public class PitchService : ICrudService<BasePitchDto>
    {
        private readonly ICrudRepository<Pitch> repository;
        private readonly IMapper mapper;

        public PitchService(ICrudRepository<Pitch> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<BasePitchDto> GetAll()
        {
            var pitchList = repository.GetAll();
            return mapper.Map<IEnumerable<BasePitchDto>>(pitchList);
        }

        public void Save(BasePitchDto dto)
        {
            var pitchModel = mapper.Map<Pitch>(dto);
            repository.Save(pitchModel);
        }

        public void Update(BasePitchDto updatedPitchDto, long id)
        {
            var pitchToUpdate = repository.GetById(id);
            var updatedPitch = mapper.Map<PutPitchDto, Pitch>((PutPitchDto)updatedPitchDto, pitchToUpdate);
            repository.Update(updatedPitch);
        }

        public Pitch GetById(long id)
        {
            return repository.GetById(id);
        }
    }
}
