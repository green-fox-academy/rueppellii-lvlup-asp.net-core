using AutoMapper;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;
using rueppellii_lvlup_asp.net_core.Services.Interfaces;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public class PitchService : IPitchService
    {
        private readonly ICrudRepository<Pitch> repository;
        private readonly IMapper mapper;

        public PitchService(ICrudRepository<Pitch> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<GetPitchDto> GetAll()
        {
            var pitchList = repository.GetAll();
            return mapper.Map<IEnumerable<GetPitchDto>>(pitchList);
        }

        public void Save(PitchDto dto)
        {
            var pitchModel = mapper.Map<Pitch>(dto);
            repository.Save(pitchModel);
        }
    }
}
