using AutoMapper;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using rueppellii_lvlup_asp.net_core.Repositories;

namespace rueppellii_lvlup_asp.net_core.Services
{
    public class PitchService : ICreateService<PostPitchDto>
    {
        private readonly ICrudRepository<Pitch> repository;
        private readonly IMapper mapper;

        public PitchService(ICrudRepository<Pitch> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Save(PostPitchDto dto)
        {
            var pitchModel = mapper.Map<Pitch>(dto);
            repository.Save(pitchModel);
        }
    }
}
