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
    public class PostPitchService : ICrudService<PostPitchDto, Pitch>
    {
        private readonly PitchRepository repository;
        private readonly IMapper mapper;

        public PostPitchService(PitchRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public IEnumerable<PostPitchDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(PostPitchDto dto)
        {
            var pitchModel = mapper.Map<Pitch>(dto);
            repository.Save(pitchModel);
        }
    }
}
