using AutoMapper;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;
using System;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public class GetPitchesService : ICrudService<PitchDto, Pitch>
    {
        private readonly ICrudRepository<Pitch> repository;
        private readonly IMapper mapper;

        public GetPitchesService(ICrudRepository<Pitch> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<PitchDto> GetAll()
        {
            var pitchList = repository.GetAll();

            return mapper.Map<IEnumerable<PitchDto>>(pitchList);
        }

        public void Save(PitchDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
